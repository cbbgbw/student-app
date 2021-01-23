import { ModalType } from '../../../types/types'
import { GetState, SetState } from 'zustand'
import { StateCombined } from '../modules'
import produce from 'immer'
import { getViewState } from '../user/userSelectors'

export const viewInitialState = {
  modalType: ModalType.None,
}

export type ViewStateCombined = typeof viewInitialState & {
  setModalType: (modalType: ModalType) => void
}

export const viewStateCombined = (
  set: SetState<StateCombined>,
  get: GetState<StateCombined>,
): ViewStateCombined => ({
  ...viewInitialState,
  setModalType: (modalType) => {
    set((prev) =>
      produce(prev, (nextState) => {
        const state = getViewState(nextState)
        state.modalType = modalType
      }),
    )
  },
})
