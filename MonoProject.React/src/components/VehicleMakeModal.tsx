import { inject, observer } from "mobx-react";
import ReactModal from "react-modal";
import UpdateVehicleMake from "./UpdateVehicleMake";

import classes from "./VehicleMakeModal.module.css"


const VehicleMakeModal = ({ modalIsOpen, setIsOpen, make }: any) => {
    function closeModal() {
        setIsOpen(false);
    }

    return (
        <ReactModal
            isOpen={modalIsOpen}
            ariaHideApp={false}
            contentLabel="Update Modal"
        >
            <div>
                <UpdateVehicleMake make={make} />
                <div className={classes.close}>

                    <button onClick={closeModal} >close</button>
                </div>
            </div>
        </ReactModal>
    );
};

export default inject("rootStore")(observer(VehicleMakeModal));