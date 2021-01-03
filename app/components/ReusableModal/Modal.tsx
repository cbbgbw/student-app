import React, { FC } from 'react'
import Modal from 'react-modal'
import styles from './Modal.module.scss'
import { Button } from '../Forms/Button/Button'

interface ReusableModalProps {
  isOpen: boolean
  children: any
  headerText: Header
  onModalLeave: () => void
  onSubmit: () => void
  acceptButtonText: string
  cancelButtonText: string
}

interface Header {
  title: string
  description: string
}

export const ReusableModal: FC<ReusableModalProps> = ({
  isOpen,
  children,
  onSubmit,
  headerText: { description, title },
  onModalLeave,
  cancelButtonText,
  acceptButtonText,
}) => (
  <Modal
    className={styles.reusableModal}
    overlayClassName={styles.modalOverlay}
    isOpen={isOpen}
    ariaHideApp={false}
  >
    <header className="modal-header">
      <h2>{title}</h2>
      <p>{description}</p>
    </header>
    <form onSubmit={onSubmit}>
      {children}
      <section className="bottom-section">
        <div className="bottom-buttons">
          <div className="flex-end">
            <Button contrast={true} onClick={onModalLeave}>
              {cancelButtonText}
            </Button>
            <Button type="submit" contrast={false}>
              {acceptButtonText}
            </Button>
          </div>
        </div>
      </section>
    </form>

    <style jsx>{`
      form {
        display: flex;
        flex-direction: column;
        padding-top: 40px;
        padding-left: 36px;
      }

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
        font-family: 'Source Sans Pro', serif;
        font-size: 26px;
        margin: 0 0 2px 0;
        color: #f1f0fa;
      }

      p {
        font-family: 'Source Sans Pro', serif;
        font-size: 16px;

        margin: 2px 0;
        color: #f1f0fa;
        opacity: 60%;
      }

      .bottom-section {
        position: absolute;
        bottom: 0;
        left: 0;
        height: 92px;
        width: 100%;
      }

      .bottom-buttons {
        height: 100%;

        margin: 0 36px;
        border-top: 1px solid black;

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
)
