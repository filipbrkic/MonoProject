import { inject, observer } from "mobx-react";
import { useRef } from "react";

import classes from "./NewVehicleMake.module.css"

const NewVehicleMake = ({ rootStore }: any) => {
    const nameInputRef = useRef<HTMLInputElement>(null);
    const abrvInputRef = useRef<HTMLInputElement>(null);

    const createVehicleMakeHandler = (() => {

        const enteredName = (nameInputRef.current as HTMLInputElement).value;
        const enteredAbrv = (abrvInputRef.current as HTMLInputElement).value;

        rootStore.newVehicleMakeViewStore.createVehicleMakeAsync({
            name: enteredName,
            abrv: enteredAbrv,
        })
    });

    return (
        <div className={classes.submit}>
            <h1>Add Vehicle Brand</h1>
            <form onSubmit={() => createVehicleMakeHandler()} >
                <div>
                    <input id="name" type="text" placeholder="Name" ref={nameInputRef} />
                </div>
                <div>
                    <input id="abrv" type="text" placeholder="Abbreviation" ref={abrvInputRef} />
                </div>
                <button className={classes.save} type="submit" >Save</button>
            </form>
        </div>
    );
}

export default inject("rootStore")(observer(NewVehicleMake));