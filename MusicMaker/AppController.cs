using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMaker
{
    class AppController
    {
        private AudioSource audio;
        public DirectSoundOut audioOutput;

        public AppController()
        {
            audio = new AudioSource();
            audioOutput = new DirectSoundOut();
        }

        public bool OpenAudio(string filename)
        {
            if (!FileHandler.OpenWav(filename, out audio))
                return false;
            else
            {
                audioOutput.Init(audio.Source);
                return true;
            }
        }

        public void UpdateDisplay()
        {
            MusicMaker.ui.DrawWave(audio.ChanL, audio.ChanR);
        }

        public double GetAudioLength()
        {
            return audio.GetTime();
        }

        public WaveFormat GetAudioProperties()
        {
            return audio.Metadata;
        }

        public WaveChannel32 GetAudioChannel()
        {
            return audio.Source;
        }

        public void Reset()
        {
            audio = new AudioSource();
            GC.Collect();
        }

        public bool PlayPause()
        {
            if (audioOutput != null)
            {
                if (audioOutput.PlaybackState == PlaybackState.Stopped || audioOutput.PlaybackState == PlaybackState.Paused)
                {
                    audioOutput.Play();
                    return true;
                }
                else if (audioOutput.PlaybackState == PlaybackState.Playing)
                {
                    audioOutput.Pause();
                    return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
