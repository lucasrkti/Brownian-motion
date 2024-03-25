using BrownianMotion.Service;


namespace BrownianMotion.Drawables
{
    public class GraphicDrawable : BaseDrawable, IDrawable
    {
        public override void Draw(ICanvas canvas, RectF dirtyRec)
        {
            double[] points = GenerateBrownian.GenerateBrownianMotian(20, 1, 100, 252);

            //points = new double[14] { 100, 20, 800, 492, 239, 80, 55, 900, 260, 600, 500, 400, 189, 990 };

            double maxValueY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                if (maxValueY < points[i])
                    maxValueY = points[i];
            }

            float realAreaX = 550;
            float realAreaY = 550;

            double ratioX = (double)realAreaX / points.Length;
            double ratioY = (double)realAreaY / maxValueY;

            canvas.StrokeColor = Colors.BlueViolet;
            canvas.FontSize = 1;
            float startX = 0;
            float startY = 0;
            float endX = 0;
            float endY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    startX = 0;
                    startY = realAreaY;
                    endX = (int)ratioX;
                    endY = realAreaY - (int)(points[i] * ratioY);
                }
                else
                {
                    startX = endX;
                    startY = endY;
                    endX = startX + (int)ratioX;
                    endY = realAreaY - (int)(points[i] * ratioY);
                }

                Point x1 = new Point(startX, startY);
                Point x2 = new Point(endX, endY);

                canvas.DrawLine(x1, x2);
            }
        }
    }
}
     
