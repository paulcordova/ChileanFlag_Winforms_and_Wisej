using System;
using System.Drawing;

public class BanderaChileDrawer
{
    public Color Azul { get; set; } = Color.FromArgb(0, 56, 168);
    public Color Rojo { get; set; } = Color.FromArgb(206, 17, 38);
    public Color Blanco { get; set; } = Color.White;

    // Dibuja la bandera dentro de 'bounds' usando el Graphics proporcionado.
    public void Draw(Graphics g, RectangleF bounds)
    {
        if (g == null) throw new ArgumentNullException(nameof(g));

        float w = bounds.Width;
        float h = bounds.Height;

        // Fondo blanco
        using (var bWhite = new SolidBrush(Blanco))
            g.FillRectangle(bWhite, bounds);

        // Cantón azul: ancho = 1/3 del ancho total, alto = 1/2 del alto total
        float cantonW = w / 3f;
        float cantonH = h / 2f;
        var cantonRect = new RectangleF(bounds.Left, bounds.Top, cantonW, cantonH);

        using (var bBlue = new SolidBrush(Azul))
            g.FillRectangle(bBlue, cantonRect);

        // Franja roja inferior
        using (var bRed = new SolidBrush(Rojo))
            g.FillRectangle(bRed, bounds.Left, bounds.Top + cantonH, w, cantonH);

        // Centro de la estrella dentro del cantón
        float xc = cantonRect.Left + cantonRect.Width / 2f;
        float yc = cantonRect.Top + cantonRect.Height / 2f;

        // Radio exterior relativo al cantón (ajustable)
        float outerRadius = Math.Min(cantonRect.Width, cantonRect.Height) * 0.35f;

        DrawStar(g, new PointF(xc, yc), outerRadius, Blanco);
    }

    // Dibuja una estrella de 5 puntas rellenada (pentagrama regular)
    private void DrawStar(Graphics g, PointF center, float outerRadius, Color fillColor)
    {
        // Ratio interno correcto para un pentagrama regular ≈ 0.381966
        double innerRatio = (3.0 - Math.Sqrt(5.0)) / 2.0;
        float innerRadius = (float)(outerRadius * innerRatio);

        PointF[] points = new PointF[10];
        double angle = -Math.PI / 2.0; // empezar apuntando hacia arriba
        double step = Math.PI / 5.0;   // 36 grados

        for (int i = 0; i < 10; i++)
        {
            double r = (i % 2 == 0) ? outerRadius : innerRadius;
            points[i] = new PointF(
                center.X + (float)(r * Math.Cos(angle)),
                center.Y + (float)(r * Math.Sin(angle))
            );
            angle += step;
        }

        using (var b = new SolidBrush(fillColor))
            g.FillPolygon(b, points);
    }
}
