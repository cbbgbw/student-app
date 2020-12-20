import React, { FC } from "react";
import Modal from "react-modal";
import styles from "./Modal.module.scss";
import { Button } from "../Forms/Button/Button";

type ReusableModalProps = {
  isOpen: boolean;
  children: any;
  headerText: Header;
  onModalLeave: () => void;
  acceptButtonText: string;
  cancelButtonText: string;
};

type Header = {
  title: string;
  description: string;
};

export const ReusableModal: FC<ReusableModalProps> = ({
  isOpen,
  children,
  headerText: { description, title },
  onModalLeave,
  cancelButtonText,
  acceptButtonText
}) => {
  return (
    <>
      <Modal
        className={styles.reusableModal}
        overlayClassName={styles.modalOverlay}
        isOpen={isOpen}
      >
        <header className={"modal-header"}>
          <h2>{title}</h2>
          <p>{description}</p>
        </header>
        {children}

        <section className={"bottom-section"}>
          <div className={"bottom-buttons"}>
            <div className={"flex-end"}>
              <Button contrast={true} onClick={onModalLeave}>
                {cancelButtonText}
              </Button>
              <Button contrast={false} onClick={() => {}}>
                {acceptButtonText}
              </Button>
            </div>
          </div>
          {/*<ChildrenWithinDivInRow>*/}

          {/*</ChildrenWithinDivInRow>*/}
        </section>
        <style jsx>{`
          .modal-header {
            height: 100px;

            padding-left: 36px;

            display: flex;
            flex-direction: column;
            justify-content: center;

            box-sizing: content-box;
            background-color: #55517a;
            border-radius: 12px 12px 0 0;
          }

          h2 {
            font-family: "Source Sans Pro", serif;
            font-size: 26px;
            margin: 0 0 2px 0;
            color: #f1f0fa;
          }
          p {
            font-family: "Source Sans Pro", serif;
            font-size: 16px;

            margin: 2px 0;
            color: #f1f0fa;
            opacity: 60%;
          }

          .bottom-section {
            position: absolute;
            bottom: 0;
            height: 92px;
            width: 100%;
          }

          .bottom-buttons {
            height: 100%;

            border-top: 1px solid black;
            margin: 0 48px;

            display: flex;
            flex-direction: column;
            justify-content: center;
          }

          .flex-end {
            display: flex;
            flex-direction: row;
            justify-content: flex-end;
          }

          div > :global(button:last-child) {
            margin-left: 28px;
          }
        `}</style>
      </Modal>
    </>
  );
};
