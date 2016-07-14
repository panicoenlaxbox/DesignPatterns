using System;

namespace Builder
{
  class MainClass
  {
    public static void Main(string[] args)
    {
      var builder = new ConcreteBuilder();
      var director = new Director(builder);
      var product = director.Build();
      Console.WriteLine(product);
    }
  }

  class Product
  {
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property3 { get; set; }

    public override string ToString()
    {
      return $"[Product: Property1={Property1}, Property2={Property2}, Property3={Property3}]";
    }
  }

  abstract class AbstractBuilder
  {
    protected readonly Product Product;

    protected AbstractBuilder()
    {
      Product = new Product();
    }

    public Product GetProduct()
    {
      return Product;
    }

    public abstract void BuildProperty1();
    public abstract void BuildProperty2();
    public abstract void BuildProperty3();
  }

  class ConcreteBuilder : AbstractBuilder
  {
    public override void BuildProperty1()
    {
      Product.Property1 = "1";
    }

    public override void BuildProperty2()
    {
      Product.Property2 = "2";
    }

    public override void BuildProperty3()
    {
      Product.Property3 = "3";
    }
  }

  class Director
  {
    private readonly AbstractBuilder _builder;

    public Director(AbstractBuilder builder)
    {
      this._builder = builder;
    }

    public Product Build()
    {
      _builder.BuildProperty1();
      _builder.BuildProperty2();
      _builder.BuildProperty3();
      return _builder.GetProduct();
    }
  }
}