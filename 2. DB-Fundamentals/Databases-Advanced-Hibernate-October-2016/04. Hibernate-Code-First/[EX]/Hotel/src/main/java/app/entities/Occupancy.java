package app.entities;

import javax.persistence.*;
import java.util.Date;

@Entity(name = "payments")
public class Occupancy {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "date_occupied")
    private Date dateOccupied;

    @Column(name = "account_number", nullable = false)
    private Long accountNumber;

    @Column(name = "room_number")
    private Long roomNumber;

    @Column(name = "rate_applied")
    private Double rateApplied;

    @Column(name = "phone_charge")
    private Integer phoneCharge;

    @Column(columnDefinition = "TEXT")
    private String notes;

    public Occupancy() {
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Date getDateOccupied() {
        return this.dateOccupied;
    }

    public void setDateOccupied(Date dateOccupied) {
        this.dateOccupied = dateOccupied;
    }

    public Long getAccountNumber() {
        return this.accountNumber;
    }

    public void setAccountNumber(Long accountNumber) {
        this.accountNumber = accountNumber;
    }

    public Long getRoomNumber() {
        return this.roomNumber;
    }

    public void setRoomNumber(Long roomNumber) {
        this.roomNumber = roomNumber;
    }

    public Double getRateApplied() {
        return this.rateApplied;
    }

    public void setRateApplied(Double rateApplied) {
        this.rateApplied = rateApplied;
    }

    public Integer getPhoneCharge() {
        return this.phoneCharge;
    }

    public void setPhoneCharge(Integer phoneCharge) {
        this.phoneCharge = phoneCharge;
    }

    public String getNotes() {
        return this.notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }
}