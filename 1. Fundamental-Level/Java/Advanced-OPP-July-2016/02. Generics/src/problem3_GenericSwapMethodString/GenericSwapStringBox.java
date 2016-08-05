package problem3_GenericSwapMethodString;

import java.util.List;

public class GenericSwapStringBox {

    public static <T> String getValueType(T value) {
        return value.getClass().getName();
    }

    public static <T> void swapElements(
            List<T> list, int firstIndex, int secondIndex) {
        T swapValue = list.get(firstIndex);
        list.set(firstIndex, list.get(secondIndex));
        list.set(secondIndex, swapValue);
    }

}
