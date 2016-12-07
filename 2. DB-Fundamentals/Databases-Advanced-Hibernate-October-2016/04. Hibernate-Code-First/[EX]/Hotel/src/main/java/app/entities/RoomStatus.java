package app.entities;

import javax.persistence.*;

@Entity(name = "room_status")
public class RoomStatus {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "room_status")
    private Long roomStatus;

    @Column(columnDefinition = "TEXT")
    private String notes;

    public RoomStatus() {
    }

    public Long getRoomStatus() {
        return this.roomStatus;
    }

    public void setRoomStatus(Long roomStatus) {
        this.roomStatus = roomStatus;
    }

    public String getNotes() {
        return this.notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }
}