import styles from "./Add.module.scss";
import { FC } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";

export type AddProps = {
  name: string;
  onClick: () => void;
};

export const Add: FC<AddProps> = ({ name, onClick }) => (
  <button className={styles.add} onClick={onClick}>
    <h1>
      Dodaj <br />
      {name}
    </h1>
    <FontAwesomeIcon icon={faPlus} size={"3x"} />
  </button>
);
