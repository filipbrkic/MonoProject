import { useRef } from "react";
import { inject, observer } from "mobx-react";

import classes from "./NewVehicleMake.module.css"

const UpdateVehicleMake = ({ rootStore, make }: any,) => {
    const nameInputRef = useRef<HTMLInputElement>(null);
    const abrvInputRef = useRef<HTMLInputElement>(null);

    const inputVehicleMakeHandler = (() => {

        const enteredName = (nameInputRef.current as HTMLInputElement).value;
        const enteredAbrv = (abrvInputRef.current as HTMLInputElement).value;

        rootStore.updateVehicleMakeViewStore.updateVehicleMakeAsync({
            id: make.id,
            name: enteredName,
            abrv: enteredAbrv,
        })
    });

    return (
        <div className={classes.submit}>
            <h1>Update Vehicle Brand</h1>
            <form onSubmit={() => inputVehicleMakeHandler()} >
                <div>
                    <input id="name" type="text" placeholder={make.name} ref={nameInputRef} />
                </div>
                <div>
                    <input id="abrv" type="text" placeholder={make.abrv} ref={abrvInputRef} />
                </div>
                <button type="submit" >Update</button>
            </form>
        </div>
    );
}

export default inject("rootStore")(observer(UpdateVehicleMake));