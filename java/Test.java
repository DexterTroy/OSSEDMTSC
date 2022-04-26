import java.io.FileNotFoundException;

public class Test {

    public static void main(String[] args) throws FileNotFoundException {

        // Add one for the class label (length)

        double[][] a = DataLoader.load("train.txt",30,571);
        double[][] b = DataLoader.load("test.txt",15,571);

        System.out.println(ONN.run(a,b));

    }
}
