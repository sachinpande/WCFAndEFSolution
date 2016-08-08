using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAndEFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            //NorthwindEntities context = new NorthwindEntities();
            //var productEntity = (from p in context.ProductEntities
            //                     where p.ProductID == id
            //                     select p).FirstOrDefault();
            //if (productEntity != null)
            //{
            //    return new Product()
            //    {
            //        ProductID = productEntity.ProductID,
            //        ProductName = productEntity.ProductName,
            //        UnitPrice = (decimal)productEntity.UnitPrice,
            //        Discontinued = productEntity.Discontinued,
            //        QuantityPerUnit = productEntity.QuantityPerUnit
            //    };
            //}
            //else
            //{
            //    throw new Exception("Invalid product id");
            //}
            
            using(var context = new NorthwindEntities())
            {
                var productEntity = context.sp_GetProductByID(id);
                if (productEntity != null)
                {
                    var product = (productEntity.FirstOrDefault());
                    if (product != null)
                    {
                        return new Product()
                        {
                            ProductID = product.ProductID,
                            ProductName = product.ProductName,
                            UnitPrice = (decimal)product.UnitPrice,
                            Discontinued = product.Discontinued,
                            QuantityPerUnit = product.QuantityPerUnit
                        };
                    }
                    else
                    {
                        throw new Exception("Invalid product id");
                    }                    
                }
                else
                {
                    throw new Exception("Invalid product id");
                }
            }
        }
    }
}
