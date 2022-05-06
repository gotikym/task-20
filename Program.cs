using System;
internal class Program
{
    static void Main(string[] args)
    {
        int hpBoss = 10000;
        int hpHero = 4000;
        int damageBoss = 325; 
        int damageHero = 150; 
        int ghostSword = damageHero; 
        bool isGhostSword = false; 
        int vampirismDamage = damageHero;
        int vampirismHeals = damageHero; 
        int raiseTheShield = 0; 
        int resetShield = 1800; 
        int numberOfShields = 2; 
        bool isRaiseTheShield = false; 
        int damageReflection = damageBoss; 
        int healsReflection = damageBoss; 
        string choiceUser;
        Console.WriteLine("Финальный БОСС - лишь начало, однако, чтобы идти дальше, ты должен победить его. Используй свои умения и снаряжение с умом, иначе будешь втоптан в землю, на которой стоишь. Удачи.");
        Console.WriteLine($"HP BOSS = {hpBoss}");
        Console.WriteLine($"Damge BOSS = {damageBoss}");
        Console.WriteLine($"HP Hero = {hpHero}");
        Console.WriteLine($"Damage Hero = {damageHero}");
        Console.WriteLine($"Shield = за спиной {numberOfShields}");
        Console.WriteLine("1 - призрачный клинок, вызывает призрачный клинок, урон = урону героя");
        Console.WriteLine("2 - Вампиризм, урон = урону героя, лечит на половину урона, можно применять только одновременно с призрачным клинком");
        Console.WriteLine("3 - Поднять щит - поднимает щит и блокирует входящий урон, будь осторожен, у тебя всего 2 щита");
        Console.WriteLine("4 - Рефлект - хилит героя на 100% от атаки босса и возвращает весь урон, можно использовать только пока щит не сломается");

        while (hpBoss >= 0 && 0 <= hpHero)
        {
            choiceUser = Console.ReadLine();
            switch (choiceUser)
            {
                case "1":
                    
                    if (raiseTheShield > 0)
                    {
                        isGhostSword = true;
                        hpBoss -= damageHero + ghostSword;
                        raiseTheShield -= damageBoss;

                        if (raiseTheShield < 0)
                        {
                            isRaiseTheShield = false;
                            hpHero -= raiseTheShield;
                            Console.WriteLine($"HP BOSS = {hpBoss}");
                            Console.WriteLine($"HP Hero = {hpHero}");
                            Console.WriteLine($"HP Shield = отсутствует \n");
                            break;
                        }
                        Console.WriteLine($"HP BOSS = {hpBoss}");
                        Console.WriteLine($"HP Hero = {hpHero}");
                        Console.WriteLine($"HP Shield = {raiseTheShield} \n");
                    }
                    else if (raiseTheShield <= 0)
                    {
                        isGhostSword = true;
                        hpBoss -= damageHero + ghostSword;
                        hpHero -= damageBoss;
                        Console.WriteLine($"HP BOSS = {hpBoss}");
                        Console.WriteLine($"HP Hero = {hpHero}");
                        Console.WriteLine($"HP Shield = отсутствует \n");
                    }
                    break;
                case "2":

                    if (raiseTheShield > 0)
                    {
                        if (isGhostSword == true)
                        {
                            isGhostSword = false;
                            hpBoss -= vampirismDamage;
                            hpHero += vampirismHeals;
                            raiseTheShield -= damageBoss;
                            
                            if (raiseTheShield < 0)
                            {
                                isRaiseTheShield = false;
                                hpHero -= raiseTheShield;
                                Console.WriteLine($"HP BOSS = {hpBoss}");
                                Console.WriteLine($"HP Hero = {hpHero}");
                                Console.WriteLine($"HP Shield = щит сломан \n");
                                break;
                            }
                            Console.WriteLine($"HP BOSS = {hpBoss}");
                            Console.WriteLine($"HP Hero = {hpHero}");
                            Console.WriteLine($"HP Shield = {raiseTheShield} \n");
                        }
                        else
                        {
                            Console.WriteLine("Сперва нужно использовать призрачный клинок");
                        }
                    }
                    if (raiseTheShield <= 0)
                    {
                        if (isGhostSword == true)
                        {
                            isGhostSword = false;
                            hpBoss -= vampirismDamage;
                            hpHero += vampirismHeals;
                            hpHero -= damageBoss;
                            Console.WriteLine($"HP BOSS = {hpBoss}");
                            Console.WriteLine($"HP Hero = {hpHero}");
                            Console.WriteLine($"HP Shield = отсутствует \n");
                        }
                        else
                        {
                            Console.WriteLine("Сперва нужно использовать призрачный клинок");
                        }
                    }
                    break;
                case "3":

                    if (numberOfShields == 0)
                    {
                        Console.WriteLine("У вас больше нет щитов");
                        break;
                    }
                    else if (numberOfShields > 0)
                    {
                        raiseTheShield = resetShield;
                        numberOfShields -= 1;
                        isRaiseTheShield = true;
                        Console.WriteLine($"Вы достали щит, у вас осталось {numberOfShields} щитов");
                        hpBoss -= damageHero;
                        raiseTheShield -= damageBoss;
                        
                        if (raiseTheShield < 0)
                        {
                            isRaiseTheShield = false;
                            hpHero -= raiseTheShield;
                            Console.WriteLine($"HP BOSS = {hpBoss}");
                            Console.WriteLine($"HP Hero = {hpHero}");
                            Console.WriteLine($"HP Shield = щит сломан \n");
                            break;
                        }
                    }
                    Console.WriteLine($"HP BOSS = {hpBoss}");
                    Console.WriteLine($"HP Hero = {hpHero}");
                    Console.WriteLine($"HP Shield = {raiseTheShield} \n");
                    break;
                case "4":
                    
                    if (isRaiseTheShield == false)
                    {
                        Console.WriteLine("Сперва нужно достать щит, если он есть.. =)");
                        Console.WriteLine($"HP BOSS = {hpBoss}");
                        Console.WriteLine($"HP Hero = {hpHero}");
                        Console.WriteLine($"Number of shield = {numberOfShields} \n");
                    }
                    else if (isRaiseTheShield == true)
                    {
                        hpBoss -= damageReflection;
                        hpHero += healsReflection;
                        raiseTheShield -= damageBoss;
                        
                        if (raiseTheShield < 0)
                        {
                            hpHero -= raiseTheShield;
                            isRaiseTheShield = false;
                            Console.WriteLine($"HP BOSS = {hpBoss}");
                            Console.WriteLine($"HP Hero = {hpHero}");
                            Console.WriteLine($"HP Shield = щит сломан \n");
                            break;
                        }
                        Console.WriteLine($"HP BOSS = {hpBoss}");
                        Console.WriteLine($"HP Hero = {hpHero}");
                        Console.WriteLine($"HP Shield = {raiseTheShield} \n");
                    }
                    break;
            }
            if (hpBoss <= 0)
            {
                Console.WriteLine("Хорош, я в тебя верил, БОСС пал");
            }
            else if (hpHero <= 0)
            {
                Console.WriteLine("Герой был разорван на части");
            }
        }
    }
}
