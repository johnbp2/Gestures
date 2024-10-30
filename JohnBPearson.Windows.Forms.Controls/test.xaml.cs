using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JohnBPearson.Windows.Forms.Controls
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : UserControl
    {
        private Storyboard sb;
            
        public test()
        {
            InitializeComponent();
        }

        private void textBlock_Loaded(object sender, RoutedEventArgs e)
        {

             this.sb = new Storyboard();
       //  sb.
            var stringAnim = new StringAnimationUsingKeyFrames();
            var duration = new Duration(new TimeSpan(0, 0, 25));
            stringAnim.Duration = duration;
            stringAnim.FillBehavior = FillBehavior.Stop;
            this.sb.Children.Add(stringAnim);
            stringAnim.RepeatBehavior = RepeatBehavior.Forever;
            //stringAnim.KeyFrames.
            // var ts = new TimeSpan(0, 0, 0);
            // var f1 = new DiscreteStringKeyFrame("", KeyTime.FromTimeSpan(ts));
            //stringAnim.KeyFrames.Add(f1);
            this.setKeyFrames(stringAnim, "aasfnjoaksdnmhl;vsao");

            Storyboard.SetTarget(stringAnim, this);

        //    textBlock.BeginAnimation(label.Content, stringAnim);
             //< BeginStoryboard >
             //               < Storyboard >
             //                   < StringAnimationUsingKeyFrames
             //   Storyboard.TargetName = "myAnimatedButton" Storyboard.TargetProperty = "Content"
             //   Duration = "0:0:8" = "Stop" >
             //                       < DiscreteStringKeyFrame Value = "" KeyTime = "0:0:0" />
             //                       < DiscreteStringKeyFrame Value = "A" KeyTime = "0:0:1" />
             //                       < DiscreteStringKeyFrame Value = "An" KeyTime = "0:0:1.5" />
             //                       < DiscreteStringKeyFrame Value = "Ani" KeyTime = "0:0:2" />
             //                       < DiscreteStringKeyFrame Value = "Anim" KeyTime = "0:0:2.5" />
             //                       < DiscreteStringKeyFrame Value = "Anima" KeyTime = "0:0:3" />
             //                       < DiscreteStringKeyFrame Value = "Animat" KeyTime = "0:0:3.5" />
             //                       < DiscreteStringKeyFrame Value = "Animate" KeyTime = "0:0:4" />
             //                       < DiscreteStringKeyFrame Value = "Animated" KeyTime = "0:0:4.5" />
             //                       < DiscreteStringKeyFrame Value = "Animated " KeyTime = "0:0:5" />
             //                       < DiscreteStringKeyFrame Value = "Animated T" KeyTime = "0:0:5.5" />
             //                       < DiscreteStringKeyFrame Value = "Animated Te" KeyTime = "0:0:6" />
             //                       < DiscreteStringKeyFrame Value = "Animated Tex" KeyTime = "0:0:6.5" />
             //                       < DiscreteStringKeyFrame Value = "Animated Text" KeyTime = "0:0:7" />
             //                   </ StringAnimationUsingKeyFrames >
             //               </ Storyboard >
             //           </ BeginStoryboard >
        }

        private void setKeyFrames(StringAnimationUsingKeyFrames stringAnim, string display)
        {
            var length = display.Length;
            var timeInterval = .5;

            var totalTime = length * timeInterval;

            for ( var i = 0; i < length; i++ )
            {
                var ts = new TimeSpan(0, 0, 0, (int)(i * timeInterval)*1000);
             
                 var   value = display.Substring(0, i);
                
                var f1 = new DiscreteStringKeyFrame(value, KeyTime.FromTimeSpan(ts));
                stringAnim.KeyFrames.Add(f1);

            }
        }
    }
}
