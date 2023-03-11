using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVNBase
{
    
    public class VNSlide
    {
        public VNImage Background;
        public List<VNImage> Perssons;
        public List<VNDialog> Dialogs;
        public bool IsChose;

        public VNSlide()
        {
            Background = null;
            Perssons = null;
            Dialogs = null;
            IsChose = false;
        }
    }

    public class VNImage
    {
        public byte[] RawData;
        public Vector2 Position;
        public float Rotation
        { 
            get 
            {
                return Rotation;
            } 
            set 
            {
                if (value > 360)
                    value = 360;
                if (value < -360)
                    value = -360;
                Rotation = value;
            } 
        }
        public Vector2 Scale;
    }

    public class VNDialog
    {
        string Text;
        VNSlide NextSlide;

        public VNDialog(string text)
        {
            Text = text;
            NextSlide = null;
        }
    }
}
