export const getItemFromDictionary = (
  obj: Record<string, string>,
  whichObjToTake = 0,
) => {
  const key = Object.keys(obj)[whichObjToTake]
  return [key, obj[key]]
}
