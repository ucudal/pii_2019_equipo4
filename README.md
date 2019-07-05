# pii_2019_equipo4

## MVC

Nuestro sistema aplica el patron MVC, Model View Controller, ya diferenciamos los modelos (la informacion), la interfaz (las paginas) y las operaciones que se realizan a la informacion (Controller). Los archivos del sistema estan organizados en diferentes directorios que reflejan este patron.
Por ejemplo, las clases en Models no dependen de las que se encuentran en Pages y viceversa. 
El controller es el contexto del sistema, se encarga de procesar la información y de interpretar las acciones de la interfaz. Ejemplo, si en Pages se registra un click de un boton se le envia un mensaje al context, que tiene la responsabilidad de cumplir dicha acción.

## Identity user

>IdentityUser() 

Initializes a new instance of IdentityUser.

>AccessFailedCount 	

Gets or sets the number of failed login attempts for the current user.

>Claims 	

Navigation property for the claims this user possesses.

>ConcurrencyStamp 	

A random value that must change whenever a user is persisted to the store

>Email 	

Gets or sets the email address for this user.

>EmailConfirmed 

Gets or sets a flag indicating if a user has confirmed their email address.

>Id 	

Gets or sets the primary key for this user.

>LockoutEnabled 	

Gets or sets a flag indicating if the user could be locked out.

>LockoutEnd 	

Gets or sets the date and time, in UTC, when any user lockout ends.

>Logins 	

Navigation property for this users login accounts.

>NormalizedEmail 	

Gets or sets the normalized email address for this user.

>NormalizedUserName 	

Gets or sets the normalized user name for this user.

>PasswordHash 	

Gets or sets a salted and hashed representation of the password for this user.

>PhoneNumber

Gets or sets a telephone number for the user.

>PhoneNumberConfirmed 	

Gets or sets a flag indicating if a user has confirmed their telephone address.

>Roles 	

Navigation property for the roles this user belongs to.

>SecurityStamp 

A random value that must change whenever a users credentials change (password changed, login removed)

>TwoFactorEnabled 

Gets or sets a flag indicating if two factor authentication is enabled for this user.

>UserName 

Gets or sets the user name for this user.

>ToString()


## Migraciones

Dotnet ef migrations add (nombre de la migracion) --context ProyectoIdentityDbContext

Dotnet ef migrations add (nombre de la migracion) --context ProjectContext

dotnet ef database update --context ProyectoIdentityDbContext

dotnet ef database update --context ProjectContext

dotnet ef migrations remove --context ProjectContext

dotnet ef migrations remove --context ProyectoIdentityDbContext
