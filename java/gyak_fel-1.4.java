// Írjunk programot, mely kiszámítja egy szám négyzetgyökét a babilóniai módszerrel!

// Az S szám négyzetgyökének megállapításához számoljuk ki az alábbi x(n) sorozat első néhány elemét. A program kérje be az S számot, és kérjen be egy epsilon pontosságot. A számolást addig folytassuk, amíg két egymást követő x(i) érték különbsége nagyobb, mint epsilon. A sorozat legutolsó kiszámított elemét írjuk ki!

import java.util.Scanner;

class Gyak_fel {

    @SuppressWarnings("resource")
    public static void main(String[] args) {
        
        Scanner sc = new Scanner(System.in);

        System.out.print("\nKérlek adj meg egy számot: ");
        double s = sc.nextDouble();

        System.out.print("Kérlek adj meg egy epsilon pontosságot: ");
        double epsilon = sc.nextDouble();

        System.out.println("\nSzám: " + s);
        System.out.println("Epsilon: " + epsilon);
        System.out.println("A végeredmény: " + BabiloniaiModszer(s, epsilon) + "\n");
    }

    public static double BabiloniaiModszer(double s, double epsilon) {
        double x0 = s / 2;
        double x1 = (x0 + s / x0) / 2;

        while (Math.abs(x1 - x0) > epsilon) {
            x0 = x1;
            x1 = (x0 + s /  x0) / 2;
        }

        return x1;
    }
}