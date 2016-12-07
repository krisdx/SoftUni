package app.entities;

import javax.persistence.*;

@Entity(name = "room_types")
public class RoomType {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "room_type")
    private Long roomStatus;

    @Column(columnDefinition = "TEXT")
    private String notes;

    public RoomType() {
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