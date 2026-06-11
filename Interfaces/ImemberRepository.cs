using API.Entities;

namespace API.Interfaces
{
    public interface ImemberRepository
    {
         void update(Member member);
         Task<bool> SaveAllAsync();
         Task<IReadOnlyList<Member>> GetMembersAsync();
         Task<Member> GetMemberByIdAsync(string id);
         Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId);


    }
}