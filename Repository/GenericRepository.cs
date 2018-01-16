using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

//Using a generic class named Tmodel 
//T ----> convencion
//Model ----> this name is because he can assume varius models
//Extends from class because class is the only acceptable type
public class GenericRepository<TModel> where TModel : class
{
    private DbContext context;
    //Method to force the repository to pass the context
    private GenericRepository()
    {
    }
    public GenericRepository(DbContext context)
    {
        this.context = context;
    }

    public void Add(TModel model)
    {
        context.Set<TModel>().Add(model);
        context.SaveChanges();
    }

    public TModel FindById(int id)
    {
        //this line finds a model with the id and automactly casts into a Tmodel
        //Set<X> -->>> fala um tipo de DBset
        //() ---> Metodoo
        //Set --> DBset<tipo especico> e dentro desssa classe do dbset tem alguns metodos
        // e dentre eles tem o Find
        return context.Set<TModel>().Find(id);        
    }

    public void Delete(int id)
    {
        TModel model = FindById(id);
        context.Set<TModel>().Remove(model);
        context.SaveChanges();
    }

    /// Returns a Generic List of all DBsets in the project
    public List<TModel> GetAll()
    {
        return context.Set<TModel>().ToList();
    }

    //Returns a Generic Edit for all objets in the project
    public void Edit(TModel modelEdited , int id)
    {
        //Type tipo = modelEdited.GetType();
        //PropertyInfo[] property = tipo.GetProperties();
        TModel model = FindById(id);
        List<string> propertyList = new List<string>();
        //foreach (var proprierties in typeof(TModel).GetProperties()) {                        
        foreach (var prop in modelEdited.GetType().GetProperties())
        {
            //modelo.propriedade = modeloEditado.propriedade
            propertyList.Add(prop.Name);
            var variableModel = model.GetType().GetProperty(prop.Name);
            variableModel = modelEdited.GetType().GetProperty(prop.Name);
            //model.GetType().GetProperty(prop.Name) = modelEdited.GetType().GetProperty(prop.Name).GetValue;
        }        
        context.SaveChanges();
    }
}