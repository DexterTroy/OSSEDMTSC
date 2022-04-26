import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;

public class DataLoader {

    public static double[][] load(String filePath, int length, int instances) throws FileNotFoundException {
        Scanner sc = new Scanner(new BufferedReader(new FileReader(filePath)));
        double [][] data = new double[length][instances];
        while(sc.hasNextLine()) {
            for (int i=0; i<data.length; i++) {
                String[] line = sc.nextLine().trim().split(",");
                for (int j=0; j<line.length; j++) {
                    data[i][j] = Double.parseDouble(line[j]);
                }
            }
        }

        return data;
    }
}
