# Projekter
Fritids projekter

* [Reparations værksted](https://github.com/Decenn/Projekter/tree/master/Reparations%20værksted)
* [Bank Case](https://github.com/Decenn/Projekter/tree/master/Bank%20Case)


## Reparations værksted
Dette projekt er det nyeste jeg har arbejdet på. Projektet går ud på at lave et værksted som bruger en SQL database.

Jeg har lavet det skalerbart f.eks ved brug af en abstract class til køretøjer.

```cs
abstract class VehicleBuilder
    {
        //Fields / Properties her...
        
        public abstract string ToString(VehicleBuilder vehicle);

        public abstract void UpdateInfo(VehicleBuilder vehicle);

        public abstract void DeleteInfo(VehicleBuilder vehicle);

        public abstract void ShowInfo(VehicleBuilder vehicle);

        public abstract int GetNextAvailableRegNr(List<VehicleBuilder> vehicles);
        
    }
 ```
Dette er en forkortet version uden de forskellige fields/properties, men det gør det nemt at tilføje/fjerne nye køretøjs classes.
Det hjælper også til at lave mere generic metode parametre så som:

```cs
CreateNewEntry(new Cars());
public static void CreateNewEntry(VehicleBuilder vehicle)
        {
            //Kode her...
        }
```

## Bank Case
Dette projekt minder lidt om værksteds projektet, men uden en ligeså god struktur. 
Projektet hjalp mig til at ligge mere fokus på min struktur, og den erfaring har jeg gjort brug af i værksteds projektet.

Jeg udviklede nogle gode og simple sorterings metoder til lister som indeholder class objekter.
```cs
 public static void LastNameSorting(List<Bruger> userList)
        {
            userList.Sort(delegate (Bruger x, Bruger y)
            {
                if (x.LastName == null && y.LastName == null) return 0;
                else if (x.LastName == null) return -1;
                else if (y.LastName == null) return 1;
                else return x.LastName.CompareTo(y.LastName);
            });
         }
```
Denne metode sortere en liste efter en Bruger's efternavn.

## Projekter fra da jeg startede
Nedenunder finder du nogle små programmer jeg lavede da jeg først startede på min uddannelse i august 2018.
Første gang jeg programmeret var da jeg startede, og derfor er de ret basic i både kodening og struktur.
Jeg har valgt at indkludere dem for at kunne minde mig selv om hvor mit niveau lå var da jeg startede.

De er sorteret fra nyeste til ældste.

### Gæstebog
* [Gæstebog](https://github.com/Decenn/Projekter/tree/master/Gæstebog)

Dette program er mit grundforløb eksamens projekt. Det går ud på at lave en database i en tekst fil.
Man skulle kunne både skrive til og læse fra databasen.

### IP Kalkulator
* [IP Kalkulator](https://github.com/Decenn/Projekter/tree/master/IPKalkulator)

Programmet kan udregne din ipv4 netværks adresse udfra den ip adresse og subnetmask du giver den.
Den kan både tage tage imod en ipv4 adresse der ser sådan ud: 
```cs
192.168.1.10 255.255.255.0
```
Men også en der ser sådan ud:
```cs
192.168.1.10/24
```
Dette var et grundforløbs eksamens projekt man kunne vælge, i stedet for Gæstebogen.
Jeg valgte at lave begge, men brugte Gæstebogen som den reele eksamens opgave.

### Hangmand
* [Hangmand](https://github.com/Decenn/Projekter/tree/master/Hangmand)

Et lille program jeg lavede i en af de første uger på grundforløbet, hvor jeg havde programmering. Det er baseret på spillet galge.

### Bytebuster
* [Bytebuster](https://github.com/Decenn/Projekter/tree/master/Bytebuster)

Et lille spil, som var en afleverings opgave i starten af grundforløbet.
