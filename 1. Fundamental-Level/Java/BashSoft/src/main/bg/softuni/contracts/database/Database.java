package main.bg.softuni.contracts.database;

import java.io.IOException;

public interface Database extends Requester, FilteredTaker, OrderedTaker {
    void loadData(String fileName) throws IOException;

    void unloadData();
}