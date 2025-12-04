using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.Attributes;

namespace VBAcousticPlugin.StoreData
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class StoreDataInElement
    {
        public StoreDataInElement(Element element, List<JunctionBuilder> allJunctions)
        {
            if (element is Wall)
            {
                StoreDataInWall((Wall)element, allJunctions);
            }
            else if (element is Ceiling)
            {
                
            }
            else if (element is Floor)
            {

            }
            else
            {
                return;
            }
        }


        void StoreDataInWall(Wall wall, List<JunctionBuilder> allJunctions) 
        {
            //ERROR:  starting a transaction from an external application running outside of API context is not allowed

            Transaction createShema = new Transaction(wall.Document, "CreateAndStore");
            createShema.Start();

            SchemaBuilder schemaBuilder =
                new SchemaBuilder(new Guid("A4CA9314-1891-412B-A825-D15346CC8928"));
            schemaBuilder.SetReadAccessLevel(AccessLevel.Public); // allow anyone to read the object
            schemaBuilder.SetWriteAccessLevel(AccessLevel.Vendor); // restrict writing to this vendor only
            schemaBuilder.SetVendorId("Camille"); // required because of restricted write-access

            schemaBuilder.SetSchemaName("Junctions");
            // create a field to store allJunctions
            FieldBuilder fieldBuilder =
                schemaBuilder.AddArrayField("Junctions", typeof(List<JunctionBuilder>));
            fieldBuilder.SetSpec(SpecTypeId.Length);
            fieldBuilder.SetDocumentation("A stored location value representing the junctions of a wall.");

            Schema schema = schemaBuilder.Finish(); // register the Schema object

            Entity entity = new Entity(schema); // create an entity (object) for this schema (class)
            // get the field from the schema
            Field fieldSpliceLocation = schema.GetField("Junctions");
            // set the value for this entity
            entity.Set<List<JunctionBuilder>>(fieldSpliceLocation, allJunctions );
            wall.SetEntity(entity); // store the entity in the element


            createShema.Commit();
        }
    }
}
