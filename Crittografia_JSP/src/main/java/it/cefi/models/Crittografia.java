package it.cefi.models;


public class Crittografia{
    public static String cripta(String frase) {
        // Normalizzazione della frase
        String testoDaCrittografare = frase.toLowerCase().replaceAll("[^a-z]", "");
        
        // Calcolo delle dimensioni del rettangolo
        int lunghezza = testoDaCrittografare.length();
        int r = (int) Math.sqrt(lunghezza);
        int c = r;
        if (r * c < lunghezza) {
            c++;
        }
        if (c - r > 1) {
            r++;
        }

        // Costruzione della matrice
        char[][] matriceCrittografia = new char[r][c];
        int k = 0;
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                if (k < lunghezza) {
                	matriceCrittografia[i][j] = testoDaCrittografare.charAt(k++);
                } else {
                	matriceCrittografia[i][j] = ' ';  // Riempie gli spazi vuoti con uno spazio
                }
            }
        }

        // Codifica del messaggio
        StringBuilder codiceCodificato = new StringBuilder();
        for (int j = 0; j < c; j++) {
            for (int i = 0; i < r; i++) {
            	codiceCodificato.append(matriceCrittografia[i][j]);
            }
            codiceCodificato.append(' '); // Aggiunge uno spazio tra i blocchi
        }

        return codiceCodificato.toString().trim();
    }
}