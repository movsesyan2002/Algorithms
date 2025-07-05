// interface IProducer<out T>
// {
//     T Produce();
// }

// interface Iconsumner<in T>
// {
//     void Consume(T item);
// }

// class Animal
// {
//    public override string ToString() => "I'm an Animal";
// }

// class Dog : Animal
// {
//     public override string ToString() => "I'm a Dog";
// }

// class Cat : Animal
// {
//     public override string ToString() => "I'm a Cat";
// }

// class ProduceAnimal<T> : IProducer<T> where T : Animal, new()
// {
//     public T Produce()
//     {
//         return new T();
//     }
// }

// class ConsumerAnimal<T> : Iconsumner<T> where T : Animal
// {
//     public void Consume(T obj)
//     {
//         Console.WriteLine(obj.ToString());
//     }
// }


// class Program
// {
//     static void Main(string[] args)
//     {
//         IProducer<Dog> produceAnimal = new ProduceAnimal<Dog>();
//         IProducer<Animal> produce = produceAnimal;

//         Animal animal = produce.Produce();
//         Console.WriteLine(animal);

//         Iconsumner<Animal> iconsumner = new ConsumerAnimal<Animal>();
//         Iconsumner<Dog> iconsumner1 = iconsumner;

//         iconsumner.Consume(animal);
//     }
// }