import { UserStateCombined, userStateCombined } from './user/user'
import { StateCreator } from 'zustand'
import { viewStateCombined, ViewStateCombined } from './view/view'

// eslint-disable-next-line @typescript-eslint/consistent-type-definitions
export type StateCombined = {
  user: UserStateCombined
  view: ViewStateCombined
}

export const combined: StateCreator<StateCombined> = (set, get) => ({
  user: userStateCombined(set, get),
  view: viewStateCombined(set, get),
})
