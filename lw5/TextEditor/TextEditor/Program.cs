using System;
using System.Collections.Generic;
using System.Text;
using TextEditor.DocumentItems.Image;

namespace TextEditor
{
    class Program
    {
        public static void Main( string[] args )
        {
            Image image = new( 384, 216, @"C:\Users\daniil.gerasimov\MyDocs\Учеба\3_stage\ood less than 3\ood\lw5\TextEditor\TextEditor\Assets\mountain.jpg" );
            image = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
