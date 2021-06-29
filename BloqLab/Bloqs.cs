using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloqLab
{
     class GetDistanceClass
     {
        static public double GetDistance(int x1, int x2, int y1, int y2)
        {
            double output  = Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
            return output;
        }
    }

    public interface IBloq
    {
        void DrawShape(Graphics g);
        int X { get; set; }
        int Y { get; set; }
        string Text { get; set; }
        bool CheckCoverage(int xm, int ym);
        void ChangeBorderToDottedLine();
        void ChangeBorderToSolidLine();
        string GetBorderStyle();
        bool CanStartDrawingLine(int xm, int ym);
        bool TryDrawLine(IBloq next, int xm, int ym);
        bool CanDrawLineToMe(int xm, int ym);
        Point getPositionDrawTo();
        bool SetPrevBloq(IBloq bloq);
        void CleanLines();
        void CleanMe(IBloq plsdeleteme);

    }

    [Serializable]
    public class RectBloq : IBloq
    {
        int x;
        int y;
        string text;
        int width = 100;
        int height = 50;
        Color frameColor = Color.Black;
        float[] dashpattern;
        string borderStyle;
        IBloq nextBloq;
        IBloq prevBloq;
        int smallElipseRadius = 10;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Text { get => text; set => text = value; }

        public RectBloq(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.text = GlobalStrings.OperatingBlockName;
            borderStyle = "solid";
            dashpattern = new float[] { 0.1f };
            nextBloq = null;
            prevBloq = null;
        }

        public void DrawShape(Graphics g)
        {
            // Create pen.
            Pen framePen = new Pen(frameColor, 2);

            // Create rectangle.
            Rectangle rect = new Rectangle(x - width / 2, y - height / 2, width, height);

            //Fill rectangle
            g.FillRectangle(new SolidBrush(Color.White), rect);

            // Create a custom dash pattern.
            framePen.DashPattern = dashpattern;

            // Create string to draw.
            String drawString = text;

            // Create font and brush.
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();

            //https://stackoverflow.com/questions/7991/center-text-output-from-graphics-drawstring
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;
            // Draw string to screen.

            g.DrawString(drawString, drawFont, drawBrush, rect, drawFormat);

            // Draw rectangle to screen.
            g.DrawRectangle(framePen, rect);

           

            // Drawing lines
            if (nextBloq==null)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x - smallElipseRadius / 2, y + height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(x - smallElipseRadius/2, y + height / 2 - smallElipseRadius/2, smallElipseRadius, smallElipseRadius));
            }else
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(8, 8);
                Pen arrowPen = new Pen(Color.Black, 2);
                arrowPen.CustomEndCap = bigArrow;
                g.DrawLine(arrowPen, new Point(x, y + height/2), nextBloq.getPositionDrawTo());
            }

            if (prevBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }


        }

        public bool CheckCoverage(int xm, int ym)
        {
            if (xm <= x + width/2 && xm >= x - width/2)
                if (ym >= y - height/2 && ym <= y + height/2)
                    return true;

            return false;
        }

        public void ChangeBorderToDottedLine()
        {
            dashpattern = new float[] { 2.0f, 2.0f };
            borderStyle = "dotted";
        }

        public void ChangeBorderToSolidLine()
        {
            dashpattern = new float[] { 0.1f };
            borderStyle = "solid";
        }

        public string GetBorderStyle()
        {
            return borderStyle;
        }

        public bool CanStartDrawingLine(int xm, int ym)
        {
            if (GetDistanceClass.GetDistance(x, xm, y + height / 2, ym) <= smallElipseRadius)
                return true;
            return false;
        }

        public bool TryDrawLine(IBloq bloq, int xm, int ym)
        {
            if (bloq == this)
                return false;

            if(bloq.CanDrawLineToMe(xm,ym))
            {
                if (this.nextBloq != null)
                    return false;

                this.nextBloq = bloq;
                bloq.SetPrevBloq(this);
                return true;
                
            }
            return false;
        }

        public bool CanDrawLineToMe(int xm, int ym)
        {
            Point test = new Point(x, y - height / 2);

            if(prevBloq == null)
            if (GetDistanceClass.GetDistance(x,xm ,  y - height/2, ym) <= smallElipseRadius)
                return true;
            return false;
        }

        public Point getPositionDrawTo()
        {
            return new Point(x, y - height / 2);
        }

        public bool SetPrevBloq(IBloq bloq)
        {
            if (prevBloq == null)
            {
                prevBloq = bloq;
                return true;
            }
            return false;
        }

        public void CleanLines()
        {
            if (prevBloq != null)
                prevBloq.CleanMe(this);
            if (nextBloq != null)
                nextBloq.CleanMe(this);
        }

        public void CleanMe(IBloq plsdeleteme)
        {
            if (prevBloq == plsdeleteme)
                prevBloq = null;
            if (nextBloq == plsdeleteme)
                nextBloq = null;
        }
    }

    [Serializable]
    public class RhombusBloq : IBloq
    {
        int x;
        int y;
        string text;
        int width = 100;
        int height = 80;
        Color frameColor = Color.Black;
        float[] dashpattern;
        IBloq rightBloq;
        IBloq leftBloq;
        IBloq prevBloq;
        int smallElipseRadius = 10;
        // Calculated rhombus vertices
        Point v1;
        Point v2;
        Point v3;
        Point v4;
        string borderStyle;
        Point drawingTempPoint;


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Text { get => text; set => text = value; }

        public RhombusBloq(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.text = GlobalStrings.DecisiveBlockName;

            // Calculate rhombus vertices
             v1 = new Point(x, y - height / 2);
             v2 = new Point(x - width / 2, y);
             v3 = new Point(x + width / 2, y);
             v4 = new Point(x, y + height / 2);

            dashpattern = new float[] { 1 };
            borderStyle = "solid";

            rightBloq = null;
            leftBloq = null;
            prevBloq = null;

            


        }

        public void DrawShape(Graphics g)
        {

            v1 = new Point(x, y - height / 2);
            v2 = new Point(x - width / 2, y);
            v3 = new Point(x + width / 2, y);
            v4 = new Point(x, y + height / 2);

            // Create pen.
            Pen framePen = new Pen(frameColor, 2);

            

            //Fill rhombus
            g.FillPolygon(new SolidBrush(Color.White), new Point[] { v1, v2, v3 });
            g.FillPolygon(new SolidBrush(Color.White), new Point[] { v4, v2, v3 });

            // Create string to draw.
            String drawString = text;

            // Create a custom dash pattern.
            framePen.DashPattern = dashpattern;

            // Create font and brush.
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();

            //https://stackoverflow.com/questions/7991/center-text-output-from-graphics-drawstring
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;
            // Draw string to screen.
            g.DrawString(drawString, drawFont, drawBrush, new Rectangle(x - width/4 ,y-height/4 + 4,50,32), drawFormat);

            // Draw rhombus to screen.
            g.DrawLine(framePen, v1, v2);
            g.DrawLine(framePen, v1, v3);
            g.DrawLine(framePen, v4, v2);
            g.DrawLine(framePen, v4, v3);

            //Draw T and F chars
            drawFont = new Font("Calibri", 10);
            string Tstring = "T";
            string Fstring = "F";
            g.DrawString(Fstring, drawFont, drawBrush, v3.X, v3.Y - 15, drawFormat);
            g.DrawString(Tstring, drawFont, drawBrush, v2.X, v2.Y - 15, drawFormat);



            // Drawing lines
            if (rightBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(v3.X - smallElipseRadius / 2, v3.Y - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(v3.X - smallElipseRadius / 2, v3.Y - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }
            else
            {   //https://www.codeproject.com/Questions/125049/Draw-an-arrow-with-big-cap
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(8, 8);
                Pen arrowPen = new Pen(Color.Black, 2);
                arrowPen.CustomEndCap = bigArrow;
                g.DrawLine(arrowPen, new Point(v3.X, v3.Y), rightBloq.getPositionDrawTo());
            }

            if (leftBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(v2.X - smallElipseRadius / 2, v2.Y  - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(v2.X - smallElipseRadius / 2, v2.Y - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }
            else
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(8, 8);
                Pen arrowPen = new Pen(Color.Black, 2);
                arrowPen.CustomEndCap = bigArrow;
                g.DrawLine(arrowPen, new Point(v2.X, v2.Y), leftBloq.getPositionDrawTo());

            }


            if (prevBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }

        }



        public bool CheckCoverage(int xm, int ym)
        {
            if (xm <= v3.X && xm >= v2.X && ym <= v4.Y && ym >= v1.Y)
                return true;

            return false;
        }

        public void ChangeBorderToDottedLine()
        {
            dashpattern = new float[] { 2.0f, 2.0f };
            borderStyle = "dotted";
        }

        public void ChangeBorderToSolidLine()
        {
            dashpattern = new float[] { 1.0f };
            borderStyle = "solid";
        }

        public string GetBorderStyle()
        {
            return borderStyle;
        }

        public bool CanStartDrawingLine(int xm, int ym)
        {
            if (GetDistanceClass.GetDistance(x + width/2, xm, y, ym) <= smallElipseRadius)
            {
                drawingTempPoint = v3;
                return true;
            }
                

            if (GetDistanceClass.GetDistance(x - width/2, xm, y, ym) <= smallElipseRadius)
            {
                drawingTempPoint = v2;
                return true;
            }
                

            return false;
        }

        public bool TryDrawLine(IBloq bloq, int xm, int ym)
        {
            if (bloq == this)
                return false;

            if (bloq.CanDrawLineToMe(xm, ym))
            {
                if(drawingTempPoint == v2)
                {
                    if (this.leftBloq != null)
                        return false;

                    this.leftBloq = bloq;
                    bloq.SetPrevBloq(this);

                    return true;
                }

                if(drawingTempPoint == v3)
                {
                    if (this.rightBloq != null)
                        return false;

                    this.rightBloq = bloq;
                    bloq.SetPrevBloq(this);

                    return true;
                }

                

                
              

            }
            return false;
        }

        public bool CanDrawLineToMe(int xm, int ym)
        {
            Point test = new Point(x, y - height / 2);

            if (prevBloq == null)
                if (GetDistanceClass.GetDistance(x, xm, y - height / 2, ym) <= smallElipseRadius)
                    return true;
            return false;
        }

        public Point getPositionDrawTo()
        {
            return new Point(x, y - height / 2);
        }

        public bool SetPrevBloq(IBloq bloq)
        {
            if (prevBloq == null)
            {
                prevBloq = bloq;
                return true;
            }
            return false;
        }

        public void CleanLines()
        {
            if (prevBloq != null)
                prevBloq.CleanMe(this);
            if (leftBloq != null)
                leftBloq.CleanMe(this);
            if (rightBloq != null)
                rightBloq.CleanMe(this);
        }

        public void CleanMe(IBloq plsdeleteme)
        {
            if (prevBloq == plsdeleteme)
                prevBloq = null;
            if (rightBloq == plsdeleteme)
                rightBloq = null;
            if (leftBloq == plsdeleteme)
                leftBloq = null;
        }
    }

    [Serializable]
    public class StartBloq : IBloq
    {
        int x;
        int y;
        string text;
        int width = 100;
        int height = 50;
        Color frameColor = Color.Green;
        float[] dashpattern;
        string borderStyle;
        IBloq nextBloq;
        
        int smallElipseRadius = 10;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Text { get => text; set => text = value; }


        public StartBloq(int x, int y)
        {
            this.x = x;
            this.y = y;     
            this.Text = GlobalStrings.StartBlockName;
            dashpattern = new float[] { 1 };
            borderStyle = "solid";
            nextBloq = null;
            
        }

        public void DrawShape(Graphics g)
        {
            // Create pen.
            Pen framePen = new Pen(frameColor, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(x - width / 2, y - height / 2, width, height);

            //Fill rectangle
            g.FillEllipse(new SolidBrush(Color.White), rect);

            // Create a custom dash pattern.
            framePen.DashPattern = dashpattern;

            // Create string to draw.
            String drawString = text;

            // Create font and brush.
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();

            //https://stackoverflow.com/questions/7991/center-text-output-from-graphics-drawstring
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;
            // Draw string to screen.
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            // Draw rectangle to screen.
            g.DrawEllipse(framePen, rect);

            // Drawing lines
            if (nextBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x - smallElipseRadius / 2, y + height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(x - smallElipseRadius / 2, y + height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }
            else
            {
                AdjustableArrowCap bigArrow = new AdjustableArrowCap(8, 8);
                Pen arrowPen = new Pen(Color.Black, 2);
                arrowPen.CustomEndCap = bigArrow;
                g.DrawLine(arrowPen, new Point(x, y + height / 2), nextBloq.getPositionDrawTo());
            }

            

        }

        public bool CheckCoverage(int xm, int ym)
        {
            // tbh nie wiem dlaczego to działa dla 0.5 
            // pewnie gdzies się we wzorze walnąłem
            return ((((xm - x) * (xm - x)) / ((width / 2) * (width / 2))) + (((ym - y) * (ym - y)) / ((height / 2) * (height / 2)))) <= 0.5;
        }

        public void ChangeBorderToDottedLine()
        {
            dashpattern = new float[] { 2.0f, 2.0f };
            borderStyle = "dotted";
        }

        public void ChangeBorderToSolidLine()
        {
            dashpattern = new float[] { 1.0f };
            borderStyle = "solid";
        }

    public string GetBorderStyle()
        {
            return borderStyle;
        }

        public bool CanStartDrawingLine(int xm, int ym)
        {
            if (GetDistanceClass.GetDistance(x, xm, y + height / 2, ym) <= smallElipseRadius)
                return true;
            return false;
        }      

        public bool TryDrawLine(IBloq bloq, int xm, int ym)
        {
            if (bloq.CanDrawLineToMe(xm, ym))
            {
                if (this.nextBloq != null)
                    return false;

                this.nextBloq = bloq;
                bloq.SetPrevBloq(this);
                return true;

            }
            return false;
        }

        public bool CanDrawLineToMe(int xm, int ym)
        {
            return false;
        }

        public Point getPositionDrawTo()
        {
            throw new NotImplementedException();
        }

        public bool SetPrevBloq(IBloq bloq)
        {
            return false;
        }

        public void CleanLines()
        {
            if(nextBloq!=null)
            nextBloq.CleanMe(this);
        }

        public void CleanMe(IBloq plsdeleteme)
        {
            nextBloq = null;
        }
    }

    [Serializable]
    public class StopBloq : IBloq
    {
        int x;
        int y;
        string text;
        int width = 100;
        int height = 50;
        Color frameColor = Color.Red;
        float[] dashpattern;
        string borderStyle;
        int smallElipseRadius = 10;
        IBloq prevBloq;
        

    public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Text { get => text; set => text = value; }

        public StopBloq(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Text = GlobalStrings.StopBlockName;
            dashpattern = new float[] { 1 };
            borderStyle = "solid";
            prevBloq = null;
        }

        public void DrawShape(Graphics g)
        {
            // Create pen.
            Pen framePen = new Pen(frameColor, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(x - width / 2, y - height / 2, width, height);

            //Fill rectangle
            g.FillEllipse(new SolidBrush(Color.White), rect);

            // Create a custom dash pattern.
            framePen.DashPattern = dashpattern;

            // Create string to draw.
            String drawString = text;

            // Create font and brush.
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();

            //https://stackoverflow.com/questions/7991/center-text-output-from-graphics-drawstring
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;
            // Draw string to screen.
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            // Draw rectangle to screen.
            g.DrawEllipse(framePen, rect);

            if (prevBloq == null)
            {
                g.FillEllipse(new SolidBrush(Color.White), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
                g.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(x - smallElipseRadius / 2, y - height / 2 - smallElipseRadius / 2, smallElipseRadius, smallElipseRadius));
            }

        }

        public bool CheckCoverage(int xm, int ym)
        {
            return ((((xm - x) * (xm - x)) / ((width / 2) * (width / 2))) + (((ym - y) * (ym - y)) / ((height / 2) * (height / 2)))) <= 0.5;
        }

        public void ChangeBorderToDottedLine()
        {
            dashpattern = new float[] { 2.0f, 2.0f };
            borderStyle = "dotted";
        }

        public void ChangeBorderToSolidLine()
        {
            dashpattern = new float[] { 1.0f };
            borderStyle = "solid";
        }

        public string GetBorderStyle()
        {
            return borderStyle;
        }

        public bool CanStartDrawingLine(int xm, int ym)
        {
            if (GetDistanceClass.GetDistance(x, xm, y + height / 2, ym) <= smallElipseRadius)
                return true;
            return false;
        }

        public bool TryDrawLine(IBloq bloq, int xm, int ym)
        {
            return false;
        }

        public bool CanDrawLineToMe(int xm, int ym)
        {
            Point test = new Point(x, y - height / 2);

            if (prevBloq == null)
                if (GetDistanceClass.GetDistance(x, xm, y - height / 2, ym) <= smallElipseRadius)
                    return true;
            return false;
        }

        public Point getPositionDrawTo()
        {
            return new Point(x, y - height / 2);
        }

        public bool SetPrevBloq(IBloq bloq)
        {
            if (prevBloq == null)
            {
                prevBloq = bloq;
                return true;
            }
            return false;
        }

        public void CleanLines()
        {
            if (prevBloq != null)
                prevBloq.CleanMe(this);
        }

        public void CleanMe(IBloq plsdeleteme)
        {
            prevBloq = null;
        }
    }

    [Serializable]
    public class SizeBloq : IBloq
    {
        int x;
        int y;
        string text = "SIZEBLOCK";
        Color frameColor = Color.White;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Text { get => text; set => text = value; }

        public SizeBloq(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public SizeBloq()
        {
        }

        public void DrawShape(Graphics g)
        {
            

        }

        public bool CheckCoverage(int xm, int ym)
        {
            return false;
        }

        public void ChangeBorderToDottedLine()
        {
            throw new NotImplementedException();
        }

        public void ChangeBorderToSolidLine()
        {
            throw new NotImplementedException();
        }

        public string GetBorderStyle()
        {
            throw new NotImplementedException();
        }

        public bool CanStartDrawingLine(int xm, int ym)
        {
            throw new NotImplementedException();
        }

        public bool TryDrawLine(IBloq next, int xm, int ym)
        {
            throw new NotImplementedException();
        }

        public bool CanDrawLineToMe(int xm, int ym)
        {
            throw new NotImplementedException();
        }

        public Point getPositionDrawTo()
        {
            throw new NotImplementedException();
        }

        public bool SetPrevBloq(IBloq bloq)
        {
            throw new NotImplementedException();
        }

        public void CleanLines()
        {
            throw new NotImplementedException();
        }

        public void CleanMe(IBloq plsdeleteme)
        {
            throw new NotImplementedException();
        }
    }



}
