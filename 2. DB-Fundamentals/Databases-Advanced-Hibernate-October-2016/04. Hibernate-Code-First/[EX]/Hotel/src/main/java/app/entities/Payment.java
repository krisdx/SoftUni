package app.entities;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;

@Entity(name = "payments")
public class Payment {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "payment_date", nullable = false)
    private Date paymentDate;

    @Column(name = "account_number", nullable = false)
    private Long accountNumber;

    @Column(name = "first_date_occupied")
    private Date firstDateOccupied;

    @Column(name = "last_date_occupied")
    private Date lastDateOccupied;

    @Column(name = "total_days")
    private Integer totalDays;

    @Column(name = "amount_charged", nullable = false)
    private BigDecimal amountCharged;

    @Column(name = "tax_rate", nullable = false)
    private Double taxRate;

    @Column(name = "tax_amount", nullable = false)
    private BigDecimal taxAmount;

    @Column(name = "total_payment", nullable = false)
    private BigDecimal totalPayment;

    @Column(columnDefinition = "TEXT")
    private String notes;

    public Payment() {
    }

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Date getPaymentDate() {
        return this.paymentDate;
    }

    public void setPaymentDate(Date paymentDate) {
        this.paymentDate = paymentDate;
    }

    public Long getAccountNumber() {
        return this.accountNumber;
    }

    public void setAccountNumber(Long accountNumber) {
        this.accountNumber = accountNumber;
    }

    public Date getFirstDateOccupied() {
        return this.firstDateOccupied;
    }

    public void setFirstDateOccupied(Date firstDateOccupied) {
        this.firstDateOccupied = firstDateOccupied;
    }

    public Date getLastDateOccupied() {
        return this.lastDateOccupied;
    }

    public void setLastDateOccupied(Date lastDateOccupied) {
        this.lastDateOccupied = lastDateOccupied;
    }

    public Integer getTotalDays() {
        return this.totalDays;
    }

    public void setTotalDays(Integer totalDays) {
        this.totalDays = totalDays;
    }

    public BigDecimal getAmountCharged() {
        return this.amountCharged;
    }

    public void setAmountCharged(BigDecimal amountCharged) {
        this.validateNegative(amountCharged);
        this.amountCharged = amountCharged;
    }

    public Double getTaxRate() {
        return this.taxRate;
    }

    public void setTaxRate(Double taxRate) {
        this.validateNegative(taxRate);
        this.taxRate = taxRate;
    }

    public BigDecimal getTaxAmount() {
        return this.taxAmount;
    }

    public void setTaxAmount(BigDecimal taxAmount) {
        this.validateNegative(taxAmount);
        this.taxAmount = taxAmount;
    }

    public BigDecimal getTotalPayment() {
        return this.totalPayment;
    }

    public void setTotalPayment(BigDecimal totalPayment) {
        this.validateNegative(totalPayment);
        this.totalPayment = totalPayment;
    }

    public String getNotes() {
        return this.notes;
    }

    public void setNotes(String notes) {
        this.notes = notes;
    }

    private void validateNegative(Double amount) {
        this.validateNegative(new BigDecimal(amount));
    }

    private void validateNegative(BigDecimal amount) {
        if (amount.compareTo(BigDecimal.ZERO) < 0) {
            throw new IllegalArgumentException("Negative amount.");
        }
    }
}