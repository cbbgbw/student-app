// import { ModalType } from "../forms/ModalWrapper";
// import create, { SetState, State } from "zustand";
//
// export const initializeStore = (preloadedStore: typeof  ini)
//
// type StoreState = {
//   modalType: ModalType;
//   setModalType: (newModalType: ModalType) => void;
// };
// export const useStore = create<StoreState>((set) => ({
//   modalType: ModalType.None
// }));
//

import { useMemo } from "react";
import create, { SetState, State } from "zustand";
import { ModalType } from "../forms/ModalWrapper";

type Store = ReturnType<typeof initStore>;

let store: ReturnType<typeof initStore>;

const initialState = {
  modalType: ModalType.None
};

type InitialState = typeof initialState;

const actions = (set: SetState<State>) => ({
  setModalType: (newModalType: ModalType) => set({ modalType: newModalType })
});

type Actions = ReturnType<typeof actions>;

function initStore(preloadedState = initialState) {
  return create((set) => {
    const as = actions(set);
    return {
      ...initialState,
      ...preloadedState,
      ...as
    };
  });
}

export const initializeStore = (preloadedState?: InitialState) => {
  let _store = store ?? initStore(preloadedState);

  // After navigating to a page with an initial Zustand state, merge that state
  // with the current state in the store, and create a new store
  if (preloadedState && store) {
    _store = initStore({
      ...store.getState(),
      ...preloadedState
    });
    // Reset the current store
    store = undefined;
  }

  // For SSG and SSR always create a new store
  if (typeof window === "undefined") return _store;
  // Create the store once in the client
  if (!store) store = _store;

  return _store;
};

export function useHydrate(initialState: InitialState) {
  const state =
    typeof initialState === "string" ? JSON.parse(initialState) : initialState;
  return useMemo(() => initializeStore(state), [state]);
}

type Statee = Actions & InitialState;

export const getModalType = (state: Statee) => ({
  modalType: state.modalType
});

export const getModalTypeSetter = (state: Statee) => ({
  setModalType: state.setModalType
});

export const getModalTypeFuncs = ({ modalType, setModalType }: Statee) => ({
  modalType,
  setModalType
});
