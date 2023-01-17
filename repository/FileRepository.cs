using BonusProject.model;
using BonusProject.validator;

namespace BonusProject.repository;

public delegate E ParseLineEntity<E>(string line);

public class FileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
{
    protected String FileName;

    protected ParseLineEntity<E> ParseLineEntity;

    public FileRepository(IValidator<E> validator, string fileName, ParseLineEntity<E> parseLineEntity) : base(validator)
    {
        FileName = fileName;
        ParseLineEntity = parseLineEntity;
        if (parseLineEntity != null)
        {
            LoadFromFile();
        } 
    }

    private void LoadFromFile()
    {
        using (var fileStream = File.OpenRead(FileName))
        using (var streamReader = new StreamReader(fileStream))
        {
            String line;
            while ((line = streamReader.ReadLine()) != null)
            {
                E entitate = ParseLineEntity(line);
                base.Save(entitate);
            }
        }    
    }
}