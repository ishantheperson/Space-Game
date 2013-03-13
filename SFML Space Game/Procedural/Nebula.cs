using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;
using SFML.Window;

using SpaceGame;
using SpaceGame.Extension;
using System.Threading;

namespace SpaceGame.Procedural {
    public class Nebula : DrawableGameObject {
        private Sprite nebula;
        private Texture nebulaTexture;


        /// <summary>
        /// Creates a new Nebula
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <param name="octave">Noise iterations</param>
        /// <param name="start">Gradient start color</param>
        /// <param name="end">Gradient end color</param>
        public Nebula(int width, int height, int octave, Color start, Color end) {
            float[,] baseNoise = WhiteNoise(width, height);
            
            float[,] perlinNoise = PerlinNoise(baseNoise, octave);

            Image nebula = new Image((uint) width, (uint) height);

            for (uint x = 0; x < width; x++) {
                for (uint y = 0; y < height; y++) {
                    byte color = (byte) ((perlinNoise[x, y] * 100) % 255);
                    nebula.SetPixel(x, y, new Color(color, color, color, 255));
                }
            }

            nebula = ApplyGradient(start, end, perlinNoise);
            
            nebulaTexture = new Texture(nebula);
            this.nebula = new Sprite(nebulaTexture);
        }

        public override void Update(RenderWindow window) {
        }

        public override void Draw(ref RenderWindow window) {
            window.Draw(nebula);
        }


        private float Interpolate(float x, float y, float a) {
            //return x * (1 - a) + (a * y);
            double f = (1 - Math.Cos(a * Math.PI)) * 0.5d;

            return (float) (x * (1 - f) + y * f);
        }

        private Color ApplyGradientColor(Color start, Color end, float t) {
            float u = 1 - t;
            return new Color((byte)((int)start.R * u + end.R * t), (byte)((int)start.G * u + end.G * t), (byte)((int)start.B * u + end.B * t), 255);
        }

        private Image ApplyGradient(Color start, Color end, float[,] noise) {
            uint width = (uint) noise.GetLength(0);
            uint height = (uint) noise.GetLength(1);

            Image image = new Image(width, height);

            for (uint x = 0; x < width; x++) {
                for (uint y = 0; y < height; y++) {
                    image.SetPixel(x, y, ApplyGradientColor(start, end, noise[x, y]));
                }
            }

            return image;
        }

        #region Noise Functions
        /// <summary>
        /// Generates array with values from 0.0 to 1.0
        /// </summary>
        /// <param name="width">Array width</param>
        /// <param name="height">Array height</param>
        /// <returns>Noise array</returns>
        private float[,] WhiteNoise(int width, int height) {
            Random random = new Random();
            float[,] noise = new float[width, height];

            for (int x = 0; x < noise.GetLength(0); x++) {
                for (int y = 0; y < noise.GetLength(1); y++) {
                    noise[x, y] = (float)random.NextDouble();
                }
            }

            return noise;
        }

        /// <summary>
        /// Generates smooth noise
        /// </summary>
        /// <param name="baseNoise">Base noise array</param>
        /// <param name="octave">kth octave</param>
        /// <returns>Smooth noise</returns>
        private float[,] SmoothNoise(float[,] baseNoise, int octave) {
            int width = baseNoise.GetLength(0);
            int height = baseNoise.GetLength(1);

            float[,] smoothNoise = new float[width, height];

            int samplePeriod = 1 << octave;
            float sampleFrequency = 1.0f / samplePeriod;

            for (int i = 0; i < width; i++) {
                int sample_x0 = (i / samplePeriod) * samplePeriod;
                int sample_x1 = (sample_x0 + samplePeriod) % width;
                float horizontalBlend = (i - sample_x0) * sampleFrequency;

                for (int j = 0; j < height; j++) {
                    int sample_y0 = (j / samplePeriod) * samplePeriod;
                    int sample_y1 = (sample_y0 + samplePeriod) % height;
                    float verticalBlend = (j - sample_y0) * sampleFrequency;

                    float top = Interpolate(baseNoise[sample_x0, sample_y0], baseNoise[sample_x1, sample_y0], horizontalBlend);
                    float bottom = Interpolate(baseNoise[sample_x0, sample_y1], baseNoise[sample_x1, sample_y1], horizontalBlend);

                    smoothNoise[i, j] = Interpolate(top, bottom, verticalBlend);
                }
            }

            return smoothNoise;
        }

        /// <summary>
        /// Generates Perlin Noise
        /// </summary>
        /// <param name="baseNoise">Base noise field</param>
        /// <param name="octaveCount">Iterations</param>
        /// <returns>Perlin noise field</returns>
        private float[,] PerlinNoise(float[,] baseNoise, int octaveCount) {
            int width = baseNoise.GetLength(0);
            int height = baseNoise.GetLength(1);

            float[][,] smoothNoise = new float[octaveCount][,]; // an array of 2d arrays

            float persistance = 0.5f;

            for (int i = 0; i < octaveCount; i++) {
                smoothNoise[i] = SmoothNoise(baseNoise, i);
            }

            float[,] perlinNoise = new float[width, height];
            float amplitude = 1.0f;
            float totalAmplitude = 0.0f;

            for (int octave = octaveCount - 1; octave >= 0; octave--) {
                amplitude *= persistance;
                totalAmplitude += amplitude;

                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        perlinNoise[i, j] += smoothNoise[octave][i, j] * amplitude;
                    }
                }
            }

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    perlinNoise[i, j] /= totalAmplitude;
                }
            }

            return perlinNoise;
        }
        #endregion
    }
}
