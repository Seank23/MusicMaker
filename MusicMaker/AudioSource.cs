using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMaker
{
    class AudioSource
    {
        short[] left, right;
        WaveFormat metadata;
        WaveChannel32 source;

        public WaveFormat Metadata
        {
            get { return metadata; }
            set { metadata = value; }
        }

        public WaveChannel32 Source
        {
            get { return source; }
            set { source = value; }
        }

        public short[] ChanL
        {
            get { return left; }
            set { left = value; }
        }

        public short[] ChanR
        {
            get { return right; }
            set { right = value; }
        }

        public double GetTime()
        {
            return left.Length / Metadata.SampleRate;
        }
    }
}
