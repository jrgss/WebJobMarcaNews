using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobMarcaNews.Data;
using WebJobMarcaNews.Models;
using WebJobMarcaNews.Repositories;
string connectionString = @"CADENA DE CONEXION";
var provider =
    new ServiceCollection()
    .AddTransient<RepositoryNoticias>()
    .AddDbContext<NoticiasContext>
    (options => options.UseSqlServer(connectionString))
    .BuildServiceProvider();
RepositoryNoticias repo = provider.GetService<RepositoryNoticias>();
List<Noticia> news = await repo.GetNoticiasAsync();
await repo.InsertarNoticiasAsync(news);

