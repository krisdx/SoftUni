package app.entities;

import javax.persistence.*;

@Entity(name = "rooms")
public class Room {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "room_number")
    private Long roomNumber;

    @Column(name = "room_type")
    private Long roomType;

    @Column(name = "bed_type")
    private Long bedType;

    @Basic
    private Double rate;

    @Column(name = "room_status")
    private Long roomtStatus;

    @Column(columnDefinition = "TEXT")
    private String notes;

    public Room() {
    }

    public Long getRoomNumber() {
        return this.roomNumber;
    }

    public void setRoomNumber(Long roomNumber) {
        this.roomNumber = roomNumber;
    }

    public Long getRoomType() {
        return this.roomType;
    }

    public void setRoomType(Long roomType) {
        this.roomType = roomType;
    }

    public Long getBedType() {
        return this.bedType;
    }

    public void setBedType(Long bedType) {
        this.bedType = bedType;
    }

    public Double getRate() {
        return this.rate;
    }

    public void setRate(Double rate) {
        this.rate = rate;
    }

    public Long getRoomtStatus() {
        return this.roomtStatus;
    }

    public void setRoomtStatus(Long roomtStatus) {
        this.roomtStatus = roomtStatus;
    }

    public String getNotes() {
        return this.notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }
}