using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Diagnostics;

namespace Blazor.Extensions.Canvas
{
  public class IndexComponent : BlazorComponent
  {
    private Canvas2dContext _context;

    protected BECanvasComponent _canvasReference;

    public bool DisableRenderButton { get; set; } = false;
    public string Timer { get; set; }

    public void Paint()
    {
      DisableRenderButton = true;
      DateTime t0 = DateTime.Now;
      Draw();
      Timer = String.Concat((DateTime.Now - t0).TotalMilliseconds, "ms");
    }

    private void Draw()
    {
      this._context = this._canvasReference.CreateCanvas2d();
      const double height = 400;
      const double width = 400;

      Complex c = new Complex(-0.1, 0.65);
      Complex copy = null;
      const int divider = 2;
      const int pixelSize = 6; // resolution

      for (double h = -(height / divider); h < (height / divider); h = h + pixelSize)
      {
        for (double w = -(width / divider); w < (width / divider); w = w + pixelSize)
        {
          var zNum = new Complex(w / (width / divider), h / (height / divider));

          int i = 0;
          copy = zNum;
          do
          {
            i++;
            zNum = zNum.kwadrat().Add(c);
          } while (zNum.modul2() < 2 && i < 30);
          int argument = i;
          do
          {
            i++;
            zNum = zNum.kwadrat().Add(c);
          } while (zNum.modul2() < 2 && i < argument * 100);

          if (argument < 30)
          {
            this._context.FillStyle = String.Concat("hsl(", argument * 12, ",100%,50%)");
            this._context.FillRect((copy.getX() + 1) * (width / divider), (copy.getY() + 1) * (height / divider), pixelSize, pixelSize);
          }
          if (i > 30)
          {
            this._context.FillStyle = String.Concat("hsl(", (i / 6) % 360, ",100%,50%)");
            this._context.FillRect((copy.getX() + 1) * (width / divider), (copy.getY() + 1) * (height / divider), pixelSize, pixelSize);
          }
        }
      }
    }
  }
}