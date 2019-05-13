# Primera Entrega

### Poster
![Poster](https://github.com/ucudal/pii_2019_equipo4/blob/master/Posters/Poster.jpeg)

## Resumen ejecutivo

### **Introducción**

>A través de la entrevista con Natalia y Carolina, del centro Ignis, pudimos desarrollar la idea de una aplicación que será útil para facilitar uno de los programas del centro que conecta técnicos de la universidad con clientes externos a la misma.

### **Objetivos Generales**

>El objetivo general del proyecto planteado es poder llegar a un modelo de aplicación web que sea efectivo para el centro Ignis.

### **Objetivos Especificos**

>Los objetivos específicos planteados son crear una aplicación web donde los alumnos y ex-alumnos de la universidad puedan contar con un usuario, un perfil y la posibilidad de poder aplicar a diferentes proyectos que estén disponibles. Por otro lado, también será posible facilitar el trabajo de las administradoras, quienes contarán con un usuario también, la posibilidad de crear proyectos, y tener acceso a una lista de personas que apliquen a un proyecto en particular.

### **Herramientas**

>Para desarrollar la aplicación, utilizaremos el lenguaje de programación C# y el framework Razor. También utilizaremos conceptos trabajados en clase, como los de patrones GRASP y principios SOLID.


>Patrones y principios: Los patrones GRASP y principios SOLID nos ayudan a poder solucionar y evitar problemas recurrentes al momento de diseñar o programar una aplicación.

>Algunos de los ejemplos de nuestro proyecto son:
La clase Proyectos, Postulantes, Filtros y DBContext utilizarán el patrón Expert, ya que son los expertos en los datos correspondientes y deberán cumplir con determinadas responsabilidades; por ejemplo la clase Postulantes se encarga de postular a los técnicos.

>También aplicamos el DIP (Inversión de dependencias) a través de diferentes interfaces como IPage, IFiltro e IPersona. Las mismas se implementarán para que los detalles dependan de las abstracciones.

>Otro ejemplo que podemos ver es el uso del SRP (Principio de responsabilidad única) en las clases Proyectos, Postulantes y Técnicos, las cuales tienen una única razón de cambio. 
