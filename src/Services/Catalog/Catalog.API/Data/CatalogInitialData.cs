using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() =>
    [
        new()
        {
            Id = new Guid("54a60249-79cc-4267-8e2b-e2251736bd02"),
            Name = "Iphone 14",
            Description = "iPhone 14: design elegante, tela Super Retina XDR de 6,1, chip A15 Bionic, câmera aprimorada para baixa luz, 5G, e recursos como Detecção de Acidentes e SOS via satélite.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = ["Smartphones"]
        },

        new()
        {
            Id = new Guid("e138fa3e-d42c-4c84-a2d8-ec7a6a16a58f"),
            Name = "Samsung Galaxy S23",
            Description = "Galaxy S23: design moderno, tela AMOLED de 6,1\", processador Snapdragon 8 Gen 2, câmeras profissionais com Nightography e conectividade 5G.",
            ImageFile = "product-2.png",
            Price = 850.00M,
            Category = ["Smartphones"]
        },

        new()
        {
            Id = new Guid("a5cbdf52-4c34-4f7b-9054-1a368b8c8e5d"),
            Name = "Dell XPS 15",
            Description = "Dell XPS 15: laptop premium com tela de 15,6\" InfinityEdge, processador Intel Core i7 de 13ª geração, 16GB RAM e SSD de 512GB.",
            ImageFile = "product-3.png",
            Price = 1600.00M,
            Category = ["Laptops"]
        },

        new()
        {
            Id = new Guid("c5798f36-4c1d-4b32-a089-31f94622cd87"),
            Name = "Apple Watch Series 8",
            Description = "Apple Watch Series 8: monitoramento avançado de saúde, rastreamento de treinos, resistência à água e conectividade GPS.",
            ImageFile = "product-4.png",
            Price = 399.00M,
            Category = ["Wearables"]
        },

        new()
        {
            Id = new Guid("af237ce1-4dbf-43b7-8105-83670edb2e9f"),
            Name = "Sony WH-1000XM5",
            Description = "Sony WH-1000XM5: fones de ouvido com cancelamento de ruído líder da categoria, som de alta qualidade e bateria de até 30 horas.",
            ImageFile = "product-5.png",
            Price = 299.00M,
            Category = ["Audio", "Headphones"]
        },

        new()
        {
            Id = new Guid("42a8593b-4812-4c62-99f3-5f63e46a0c41"),
            Name = "Amazon Echo Dot (5ª Geração)",
            Description = "Echo Dot 5ª Geração: assistente virtual Alexa com som aprimorado e design compacto para qualquer ambiente.",
            ImageFile = "product-6.png",
            Price = 49.99M,
            Category = ["Smart Home"]
        },

        new()
        {
            Id = new Guid("bf3ec67a-d9db-4df4-a6a8-017ab788cba6"),
            Name = "GoPro HERO12 Black",
            Description = "GoPro HERO12 Black: câmera de ação com estabilização HyperSmooth, captura 5.3K a 60fps e resistência à água.",
            ImageFile = "product-7.png",
            Price = 399.99M,
            Category = ["Cameras"]
        },

        new()
        {
            Id = new Guid("e7d7648f-d579-4e93-90db-98ad3ae48c74"),
            Name = "Kindle Paperwhite",
            Description = "Kindle Paperwhite: leitor digital com tela antirreflexo de 6,8\", ajuste de luz quente e bateria de longa duração.",
            ImageFile = "product-8.png",
            Price = 139.99M,
            Category = ["E-Readers"]
        }
    ];
}
