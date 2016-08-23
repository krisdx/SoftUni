package behavioral.mementoPattern.models.originator;

public interface SalesProspect extends Originator {
	String getName();
	
	void setName(String name);
	
	String getPhone();
	
	void setPhone(String phone);
	
	double getBudget();
	
	void setBudget(double budget);
}