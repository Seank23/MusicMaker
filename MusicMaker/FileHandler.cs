using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMaker
{
    class FileHandler
    {
        public static bool OpenWav(string filename, out AudioSource audio)
        {
            audio = new AudioSource();
            using (WaveFileReader reader = new WaveFileReader(filename))
            {
                if (reader.WaveFormat.BitsPerSample != 16)
                {
                    Console.WriteLine("Only works with 16 bit audio");
                    return false;
                }

                audio.Metadata = reader.WaveFormat;
                audio.Source = new NAudio.Wave.WaveChannel32(reader);

                byte[] buffer = new byte[reader.Length];
                int read = reader.Read(buffer, 0, buffer.Length);
                short[] sampleBuffer = new short[read / 2];
                Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);

                if (reader.WaveFormat.Channels == 2)
                {
                    audio.ChanL = new short[sampleBuffer.Length / 2];
                    audio.ChanR = new short[sampleBuffer.Length / 2];
                    for (int i = 0; i < sampleBuffer.Length; i += 2)
                    {
                        audio.ChanL[i / 2] = sampleBuffer[i];
                        audio.ChanR[i / 2] = sampleBuffer[i + 1];
                    }
                }
                else
                {
                    audio.ChanL = sampleBuffer;
                }
                return true;
            }
        }

        public static short[] CompressWave(short[] origWave, int compFactor)
        {
            short[] compWave = new short[origWave.Length / compFactor];
            int avgAmp = 0;
            for(int i = 0; i <  compWave.Length; i++)
            {
                for(int j = i * compFactor; j < i * compFactor + compFactor; j++)
                {
                    avgAmp += origWave[j];
                }
                avgAmp /= compFactor;
                compWave[i] = (short)avgAmp;
            }
            return compWave;
        }
    }
}
