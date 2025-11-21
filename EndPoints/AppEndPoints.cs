namespace FirstMinimalApiProject.EndPoints
{
    public static class AppEndPoints
    {
        public static WebApplication MapAppEndPoints(this WebApplication app)
        {
            app.MapBooksEndPoints();
            return app;
        }
    }
}
