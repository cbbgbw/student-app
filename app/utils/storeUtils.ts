import create from 'zustand'
import { devtools } from 'zustand/middleware'
import { useMemo } from 'react'
import { combined, StateCombined } from '../store/modules/modules'

export type StoreType = ReturnType<typeof createStore>

export const createStore = (
  preloadedState = combined, // retype initialStates
) =>
  create<StateCombined>(
    devtools((set, get, api) => ({
      ...combined(set, get, api), // first - shape
      ...preloadedState, // second - override shape with changeable state variables
    })),
  )

let store: StoreType

export const initializeStore = (preloadedState: any) => {
  let _store = store ?? createStore(preloadedState)

  // After navigating to a page with an initial Zustand state, merge that state
  // with the current state in the store, and create a new store
  if (preloadedState && store) {
    _store = createStore({
      ...store.getState(),
      ...preloadedState,
    })
    // Reset the current store
    store = ({} as unknown) as Hydrate
  }

  // For SSG and SSR always create a new store
  if (typeof window === 'undefined') return _store
  // Create the store once in the client
  if (!store) store = _store

  return _store
}

export function useHydrate(initialState: any) {
  const state = initialState
  return useMemo(() => initializeStore(state), [state])
}

export type Hydrate = ReturnType<typeof useHydrate>
