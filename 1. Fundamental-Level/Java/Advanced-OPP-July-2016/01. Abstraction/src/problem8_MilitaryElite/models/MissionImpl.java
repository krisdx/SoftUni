package problem8_MilitaryElite.models;

import problem8_MilitaryElite.contracts.Mission;

public class MissionImpl implements Mission {
    private String codeName;
    private String state;

    public MissionImpl(String codeName, String state) {
        this.codeName = codeName;
        this.setState(state);
    }

    @Override
    public String getCodeName() {
        return this.codeName;
    }

    @Override
    public String getState() {
        return this.state;
    }

    @Override
    public void completeMission() {
        this.state = "Finished";
    }

    @Override
    public String toString() {
        return String.format("Code Name: %s State: %s",
                this.codeName, this.state);
    }

    private void setState(String state) {
        if (!state.equals("inProgress") && !state.equals("Finished")) {
            throw new IllegalArgumentException(
                    "The state of the mission must be inProgress or Finished");
        }

        this.state = state;
    }
}