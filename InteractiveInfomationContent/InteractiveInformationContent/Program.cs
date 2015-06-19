using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveInformationContent
{
    public  class Dictionary<Tkey1, Tkey2, TValue> : Dictionary<Tuple<Tkey1, Tkey2>, TValue>//Dictionaryクラスの拡張
    {        public TValue this[Tkey1 key1, Tkey2 key2]
        {
            get { return this[Tuple.Create(key1, key2)]; }
            set { this[Tuple.Create(key1, key2)] = value; }
        }
    }
    class Program 
    {
        enum weather
        {
            sunny,//x or y=0 =>晴れ,x or y=1 =>曇り,x or y=2 =>雨
            cloudy,
            rainny
        }
         [STAThreadAttribute]
        static void Main(string[] args)
        {
            int N =27;
            int basenum = 10;
            var px =new Dictionary<int,double>();
            var py=new  Dictionary<int,double>(); //x=東京の天気,y=大阪の天気,g:givenの略字
            double dklpxy_pxpy=0;
            double hxy=0,hxgy=0,hygx=0,hx=0,hy=0;
            var ixy = new List<double>();   
            Dictionary<int, int, double> pxy = new Dictionary<int, int, double>();
            Dictionary<int, int, double> pxgy = new Dictionary<int, int, double>();
            Dictionary<int, int, double> pygx = new Dictionary<int, int, double>();
            //double[] probabilities = new double[] { 0.19, 0.11, 0.06, 0.09, 0.17, 0.15, 0.04, 0.07, 0.12 };

            double[] xprobabilities = new double[] { 0.0575, 0.0128, 0.0263, 0.0285, 0.0913, 0.0173, 0.0133, 0.0313, 0.0599,0.0006,0.0084,0.0335,0.0235,0.0596,0.0689,0.0192,0.0008,0.0508,0.0567,0.0706,0.0334,0.0069,0.0119,0.0073,0.0164,0.0007,0.1928 };
          //  double[] yprobabilities = new double[] { 0.19, 0.11, 0.06, 0.09, 0.17, 0.15, 0.04, 0.07, 0.12 };
            string[] definitions = new string[] { "H[x]-H[x|y]=", "H[y]-H[y|x]=", "H[x]+H[y]-H[x,y]=", "Dkl[p(x,y)||p(x)p(y)]=" };

            N = xprobabilities.Length;

              for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                   pxy[i, j] = (double)(xprobabilities[i]/N);
                   hxy += pxy[i, j] * Math.Log((double)1 / pxy[i, j], basenum);
                   
                   
                }
            }

            for (int i = 0; i < N; i++)
            {
                double tmpx = 0;
                double tmpy = 0;
                for (int j = 0; j < N; j++)
                {
                    tmpx += pxy[i, j];
                    tmpy += pxy[j, i];
                }
                px[i] = tmpx;
                py[i] = tmpy;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    pxgy[i, j] = (double)pxy[i, j] / py[j];
                    pygx[j, i] = (double)pxy[i, j] / px[i];
                   
                        hxgy += pxy[i, j] * Math.Log((double)1 / pxgy[i, j], basenum);
                        hygx += pxy[i, j] * Math.Log((double)1 / pygx[j, i], basenum);
                        dklpxy_pxpy += pxy[i, j] * Math.Log(pxy[i, j] / (px[i] * py[j]), basenum);
                    
                    }
            }
            for (int i = 0; i < N; i++)
            {
                hx += px[i] * Math.Log((double)1 / px[i], basenum);
                hy += py[i] * Math.Log((double)1 / py[i], basenum);
            }


          //  double[] probabilities = new double[] { 0.19, 0.11, 0.06, 0.09, 0.17, 0.15, 0.04, 0.07, 0.12 };
           /*アルファベットエニグマ
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                   if(i==j) pxy[i, j] = xprobabilities[i]*0;
                   else { pxy[i, j] = (double)(xprobabilities[i]/(N-1));
                   hxy += pxy[i, j] * Math.Log((double)1 / pxy[i, j], basenum);
                   }
                   
                }
            }

            for (int i = 0; i < N; i++)
            {
                double tmpx = 0;
                double tmpy = 0;
                for (int j = 0; j < N; j++)
                {
                    tmpx += pxy[i, j];
                    tmpy += pxy[j, i];
                }
                px[i] = tmpx;
                py[i] = tmpy;
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    pxgy[i, j] = (double)pxy[i, j] / py[j];
                    pygx[j, i] = (double)pxy[i, j] / px[i];
                    if (i != j)
                    {
                        hxgy += pxy[i, j] * Math.Log((double)1 / pxgy[i, j], basenum);
                        hygx += pxy[i, j] * Math.Log((double)1 / pygx[j, i], basenum);
                        dklpxy_pxpy += pxy[i, j] * Math.Log(pxy[i, j] / (px[i] * py[j]), basenum);
                    }
                    }
            }
            for (int i = 0; i < N; i++)
            {
                hx += px[i] * Math.Log((double)1 / px[i], basenum);
                hy += py[i] * Math.Log((double)1 / py[i], basenum);
            }
             */
            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        pxy[i, j] = probabilities[i*N+j];
            //        hxy += pxy[i, j] * Math.Log((double)1/pxy[i,j],basenum);
            //    }
            //}
            //for (int i = 0; i < N; i++)
            //{
            //    double tmpx = 0;
            //    double tmpy = 0;
            //    for (int j = 0; j < N; j++)
            //    {
            //            tmpx += pxy[i, j];
            //            tmpy += pxy[j, i];
            //                      }
            //    px[i] = tmpx;
            //    py[i] = tmpy;
            //}
            // for(int i=0;i<N;i++){
            //    for(int j=0;j<N;j++){
            //        pxgy[i,j]=(double) pxy[i,j]/py[j];
            //        pygx[j, i] = (double)pxy[i, j] / px[i];
            //        hxgy+=pxy[i,j]*Math.Log((double)1/pxgy[i,j],basenum);
            //        hygx += pxy[i, j] * Math.Log((double)1 / pygx[j,i],basenum);
            //        dklpxy_pxpy+=pxy[i,j]*Math.Log(pxy[i,j]/(px[i]*py[j]),basenum);
            //    }
            //}
            // for (int i = 0; i < N; i++)
            // {
            //     hx += px[i] * Math.Log((double)1 / px[i], basenum);
            //     hy += py[i] * Math.Log((double)1 / py[i], basenum);
            // }
            ixy.Add(hx - hxgy);
            ixy.Add(hy-hygx);
            ixy.Add(hx+hy-hxy);
            ixy.Add(dklpxy_pxpy);
            string str = definitions[0] + ixy[0];
            for (int n = 0; n < ixy.Count;n++)
            {
                Console.WriteLine(definitions[n]+ixy[n]);
               
            }
            Clipboard.SetDataObject(str, true);
        }
    }
}/*out
  * H[x]-H[x|y]          =0.101415824911805
  * H[y]-H[y|x]          =0.101415824911805
  * H[x]+H[y]-H[x,y]     =0.101415824911805
  * Dkl[p(x,y)||p(x)p(y)]=0.101415824911805
  */
