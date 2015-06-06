using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Chart chart = new Chart();

            chart.ChartAreas.Add(new ChartArea());


            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            for (int x = 0; x < 3; x++)
            {
                int ptIdx = chart.Series["Data"].Points.AddXY(
                     90,
                     90);
                DataPoint pt = chart.Series["Data"].Points[ptIdx];
                pt.LegendText = "#VALX: #VALY";
                pt.LegendUrl = "/Contact/Details/Hey";
            }


            chart.Series["Data"].Label = "#PERCENT{P0}";

            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";





            chart.Series.Add(new Series("Data1"));
            chart.Series["Data1"].ChartType = SeriesChartType.Pie;
  //          chart.Series["Data1"]["PieLabelStyle"] = "Inside";
            chart.Series["Data1"]["PieLineColor"] = "Black";
            for (int x = 0; x < 4; x++)
            {
                int ptIdx = chart.Series["Data1"].Points.AddXY(
                     60,
                     60);
                DataPoint pt = chart.Series["Data1"].Points[ptIdx];
                pt.LegendText = "#VALX: #VALY";
                pt.LegendUrl = "/Contact/Details/Hey";
            }


            chart.Series["Data1"].Label = "#PERCENT{P0}";

            chart.Series["Data1"].ChartType = SeriesChartType.Pie;
//            chart.Series["Data1"]["PieLabelStyle"] = "Inside";
            //chart.Series["Data1"].Legend = "Stores";

    

        
            
            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms, ChartImageFormat.Bmp);




            CustomChart chart1 = new CustomChart(ms);
            chart1.Width = 200;
            chart1.Height = 300;
            chart1.ChartAreas.Add(new ChartArea());


            chart1.Series.Add(new Series("Data"));
            chart1.Series["Data"].ChartType = SeriesChartType.Pie;
            chart1.Series["Data"]["PieLabelStyle"] = "Inside";
            chart1.Series["Data"]["PieLineColor"] = "Black";
            for (int x = 0; x < 5; x++)
            {
                int ptIdx = chart1.Series["Data"].Points.AddXY(
                     90,
                     90);
                DataPoint pt = chart1.Series["Data"].Points[ptIdx];
                pt.LegendText = "#VALX: #VALY";
                pt.LegendUrl = "/Contact/Details/Hey";
            }

            chart1.Series["Data"].Label = "#PERCENT{P0}";

            chart1.paa();
            MemoryStream ms1 = new MemoryStream();
            chart1.SaveImage(ms1, ChartImageFormat.Png);


            return File(ms1.ToArray(), "image/png");

        }

        public class CustomChart:Chart
        {
            MemoryStream mss;

            public CustomChart(MemoryStream ms)
            {
                this.mss = ms;
            }
            public void paa()
            {
                
            }

            public new void Paint(Graphics g, Rectangle Position)
            {
                base.Paint(g,Position);
                System.Drawing.Image imgSave = System.Drawing.Image.FromStream(this.mss);
//                Pen pen = new Pen();
                g.DrawLine(new Pen(Color.Black),0,0,200,200);
                g.DrawImage(imgSave,0,0);
                g.Save();


            }

         }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected ActionResult chart()
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;
            chart.Series["Data"]["PieLabelStyle"] = "Outside";
            chart.Series["Data"]["PieLineColor"] = "Black";
            chart.Series["Data"].Points.DataBindXY(
                "x",
                "y");
            //Other chart formatting and data source omitted.

            MemoryStream ms = new MemoryStream();
            chart.SaveImage(ms, ChartImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }
    }
}
