package app.entities;

import javax.persistence.*;
import java.math.BigDecimal;

@Entity(name = "bed_type")
public class BedType {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "bed_type")
    private Long roomStatus;

    @Column(columnDefinition = "TEXT")
    private String notes;

    @Basic
    private BigDecimal test;

    public BedType() {
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