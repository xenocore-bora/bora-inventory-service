using Inventory.Domain.Aggregates.Brands;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;

namespace Inventory.Infrastructure.Seeder.Entities;

public class BrandSeeder : EntitySeeder<Brand>
{
    public override int Order => 1;
    protected override string TableName => "brands";

    protected override IList<Brand> GenerateData()
    {
        return new List<Brand>
        {
            new(Guid.Parse("da180a0b-a7bd-4007-8f63-6c1435c8d55d"), "Fotric"),
            new(Guid.Parse("269fbe73-4c02-40c9-9d93-befb0ae3bca1"), "PROFIBUS"),
            new(Guid.Parse("732753c8-d0b6-4b20-9b99-6ad63cfd0aa6"), "Beamex"),
            new(Guid.Parse("8ceb6bd8-dc51-4d30-b7b1-27d7c7780cf1"), "Siemens"),
            new(Guid.Parse("6536b41f-4a2e-479c-8ff7-e090661da269"), "Schneider Electric"),
            new(Guid.Parse("f9251423-eb02-4028-a472-3e503d98827e"), "ABB"),
            new (Guid.Parse("cb42344b-215f-4bf2-9556-0c0c5cb07f81"), "Rockwell Automation"),
            new (Guid.Parse("fe9742f2-77f5-4c47-9bde-9b39d79edf11"), "Endress+Hauser"),
            new (Guid.Parse("9c1e9d7c-3b13-4a17-bad7-268b7c66f8ea"), "WEG"),
            new (Guid.Parse("1af550f4-6ff2-4fc3-bd37-0b38e673b244"), "Eaton"),
            new (Guid.Parse("ed66a743-e8c6-47cd-aec3-c45dfdeb8fdc"), "Phoenix Contact"),
            new (Guid.Parse("19bb48ba-8794-4778-b104-f9b66decd02a"), "Festo"),
            new (Guid.Parse("dd8c1262-da54-438c-8ad0-defcfbc5e433"), "SEW-Eurodrive"),
            new (Guid.Parse("3f9f6965-389e-4d5f-a6c5-cb2f29e0aeea"), "Fluke"),
            new (Guid.Parse("122ba7cb-bb3e-44dc-93a7-1ea42d7e9bb1"), "Yokogawa"),
            new (Guid.Parse("326aafad-b9e8-4523-9ac6-947b081e897b"), "Honeywell"),
            new (Guid.Parse("97eeedc1-15d0-4637-bc54-5f1643090862"), "Pepperl+Fuchs"),
            new (Guid.Parse("4d36fd7e-2bcb-420e-a9a9-eb0491cdda64"), "Balluff"),
            new (Guid.Parse("255780ba-d602-4aeb-a273-1388dfe49aa2"), "Rittal"),
            new (Guid.Parse("dd58c666-752d-4d02-9b2f-b860ce299b37"), "Turck")
        };
    }
}