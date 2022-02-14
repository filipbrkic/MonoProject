import { inject, observer } from "mobx-react";

import classes from "./VehicleMakeList.module.css"


const DeleteVehicleMake = ({ rootStore, make }: any) => {
    const deleteVehicleHandler = () => {
        rootStore.deleteVehicleMakeViewStore.deleteCountryAsync(make.id);
    };

    return (
        <button className={classes.delete} onClick={deleteVehicleHandler} >Delete</button>
    )
};

export default inject("rootStore")(observer(DeleteVehicleMake));