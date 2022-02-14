import { inject, observer } from "mobx-react";

const DeleteVehicleMake = ({ rootStore, make }: any) => {
    const deleteVehicleHandler = () => {
        rootStore.deleteVehicleMakeViewStore.deleteCountryAsync(make.id);
    };

    return (
        <button onClick={deleteVehicleHandler} >Delete</button>
    )
};

export default inject("rootStore")(observer(DeleteVehicleMake));