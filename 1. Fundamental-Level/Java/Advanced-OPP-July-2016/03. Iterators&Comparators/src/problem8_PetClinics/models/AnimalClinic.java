package problem8_PetClinics.models;

import problem8_PetClinics.contracts.Clinic;

import java.util.*;

public class AnimalClinic implements Clinic {

    private String name;
    private int roomsCount;
    private int leftSideRoomIndex;
    private int rightSideRoomIndex;

    private boolean hasEntered;
    private boolean hasToPutOnLeftSide;

    private Map<Integer, Animal> rooms;

    public AnimalClinic(String name, int roomsCount) {
        this.name = name;
        this.setRoomsCount(roomsCount);
        this.setLeftSideRoomIndex();
        this.setRightSideRoomIndex();
        this.initRooms();
        this.hasToPutOnLeftSide = true;
    }

    @Override
    public boolean addAnimal(Animal animal) {
        if (!this.hasEntered) {
            this.rooms.put(this.getMiddleRoom(), animal);
            this.hasEntered = true;
            return true;
        }

        if (this.hasToPutOnLeftSide && this.leftSideRoomIndex >= 0) {
            this.rooms.put(this.leftSideRoomIndex, animal);
            this.leftSideRoomIndex--;
            this.hasToPutOnLeftSide = false;
            return true;
        } else if (!this.hasToPutOnLeftSide && this.rightSideRoomIndex < this.roomsCount) {
            this.rooms.put(this.rightSideRoomIndex, animal);
            this.rightSideRoomIndex++;
            this.hasToPutOnLeftSide = true;
            return true;
        }

        return false;
    }

    @Override
    public boolean releaseAnimal() {
        boolean hasReachedEnd = false;
        int index = this.getMiddleRoom();
        while (true) {
            Animal animal = this.rooms.get(index);
            if (animal != null) {
                // Removing the animal form the clinic
                this.rooms.put(index, null);
                return true;
            } else {
                index++;
                if (index >= this.roomsCount) {
                    index = 0;
                    hasReachedEnd = true;
                }
            }

            if (hasReachedEnd && index >= this.getMiddleRoom()) {
                return false;
            }
        }
    }

    @Override
    public boolean hasEmptyRooms() {
        for (Map.Entry<Integer, Animal> entry : this.rooms.entrySet()) {
            if (entry.getValue() == null) {
                return true;
            }
        }

        return false;
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        for (Map.Entry<Integer, Animal> entry : rooms.entrySet()) {
            if (entry.getValue() == null) {
                output.append("Room empty")
                        .append(System.lineSeparator());
            } else {
                output.append(entry.getValue().toString())
                        .append(System.lineSeparator());
            }
        }

        return output.toString().trim();
    }

    public String getName() {
        return this.name;
    }

    public Map<Integer, Animal> getRooms() {
        return this.rooms;
    }

    private int getMiddleRoom() {
        return this.roomsCount / 2;
    }

    private void setRoomsCount(int roomsCount) {
        if (roomsCount % 2 == 0) {
            throw new IllegalArgumentException(
                    "Invalid Operation!");
        }

        this.roomsCount = roomsCount;
    }

    private void setLeftSideRoomIndex() {
        this.leftSideRoomIndex = (this.roomsCount / 2) - 1;
    }

    private void setRightSideRoomIndex() {
        this.rightSideRoomIndex = (this.roomsCount / 2) + 1;
    }

    private void initRooms() {
        this.rooms = new TreeMap<>();
        for (int i = 0; i < this.roomsCount; i++) {
            this.rooms.put(i, null);
        }
    }
}